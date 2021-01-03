using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe.Web.Data;
using Recipe.Web.Data.Extensions;
using Recipe.Web.Data.Models;
using Recipe.Web.Data.Utilities;
using Recipe.Web.Server.Services;
using MoreLinq;

namespace Recipe.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> logger;
        private readonly RecipeContext context;
        private readonly HttpClient httpClient;

        public RecipeController(ILogger<RecipeController> logger, RecipeContext context, HttpClient httpClient)
        {
            this.logger = logger;
            this.context = context;
            this.httpClient = httpClient;
        }

        [HttpPost]
        public async Task<ActionResult<InTheFridgeRecipe[]>> SearchForRecipes(SpoonacularRecipeSearchModel searchModel)
        {
            // Create endpoint builder and add parameters for the complex search endpoint for bulk recipe data
            var endpointBuilder = new SpoonacularApiEndpointBuilder(SpoonacularApiEndpoint.ComplexSearch);
            endpointBuilder.AddParameter<string>("query", searchModel.SearchString);
            endpointBuilder.AddParameter<int>("number", searchModel.NumberOfResults);

            // If any filters were selected, add to list of intolerences
            var listOfIntolerances = new List<string>();

            if (searchModel.IsDairyFree)
                listOfIntolerances.Add("Dairy");

            if (searchModel.IsGlutenFree)
                listOfIntolerances.Add("Gluten");

            if (searchModel.IsVegetarian)
                listOfIntolerances.Add("Vegetarian");

            // Use AddParameters function to add complex multi-value parameter with a specific delimiter
            // i.e. ...&intolerances=Dairy,Gluten,Vegetarian&...
            if (listOfIntolerances.Any())
                endpointBuilder.AddParameters("intolerances", ",", listOfIntolerances.ToArray());

            // Build endpoint and get a spoonacular response from complex search api endpoint
            var apiRoute = endpointBuilder.BuildEndpoint();
            var spoonacularResponse = await httpClient.GetFromJsonAsync<SpoonacularRecipeComplexSearchResponse>(apiRoute);

            // Get all the recipe ids from complex query response in preperation for Bulk Recipes api endpoint request
            var recipeIds = spoonacularResponse.Results.Select(e => e.Id).ToArray();
            SpoonacularRecipe[] spoonRecipes = null;

            // If any recipes are found, request the bulk recipes endpoint using the ids gathered from above
            if (recipeIds.Any())
            {
                // Use AddParameters function to add complex multi-value parameter with a specific delimiter
                // i.e. ...&ids=101,102,103&...
                endpointBuilder = new SpoonacularApiEndpointBuilder(SpoonacularApiEndpoint.BulkRecipeByIds);
                endpointBuilder.AddParameters("ids", ",", recipeIds);
                var apiRouteRecipes = endpointBuilder.BuildEndpoint();
                
                var response = await httpClient.GetAsync(apiRouteRecipes);
                var json = await response.Content.ReadAsStringAsync();
                try
                {
                spoonRecipes = JsonSerializer.Deserialize<SpoonacularRecipe[]>(json);
                }
                catch (Exception e)
                {

                }
            }

            // Gather recipes stored in the recipes table that contains the search query in the name and description of the recipe.
            var inTheFridgeRecipes = context.Recipes
                .Where(r => r.Name.ToLower().Contains(searchModel.SearchString.ToLower()) ||
                            r.Description.ToLower().Contains(searchModel.SearchString.ToLower()))
                .ToList();

            // Map spoonacular recipes to InTheFridgeRecipes.
            var mappingService = new RecipeMappingService();
            var mappedRecipes = mappingService.MapTo(spoonRecipes).ToList();

            // If there are any recipes in the database, lets remove some from api results so we dont display the same recipe twice.
            if (inTheFridgeRecipes.Any() || mappedRecipes.Any())
            {
                var allRecipes = inTheFridgeRecipes.Concat(mappedRecipes).ToList();
                var recipesToRender = allRecipes.DistinctBy(e => e.Name).DistinctBy(e => e.Description).ToList();
                var distinctRecipes = allRecipes.ExceptBy(inTheFridgeRecipes, e => e.Description);

                if (distinctRecipes.Any())
                {
                    context.Recipes.AddRange(distinctRecipes);
                    context.SaveChanges();
                }

                return Ok(recipesToRender);
            }

            return NoContent();
        }

        private async Task<SpoonacularRecipe[]> GetApiResponseFromSpoonacular(string searchString)
        {
            var helper = new SpoonacularApiEndpointBuilder(SpoonacularApiEndpoint.ComplexSearch);
            helper.AddParameter("query", searchString);
            helper.AddParameter("number", 10);
            var spoonacularRecipes = await httpClient.GetFromJsonAsync<SpoonacularRecipe[]>(helper.BuildEndpoint());

            return spoonacularRecipes;
        }

    }

}
