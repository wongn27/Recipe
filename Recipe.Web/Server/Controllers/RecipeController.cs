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
using Recipe.Web.Data.Models;
using Recipe.Web.Data.Utilities;
using Recipe.Web.Server.Services;

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
        public async Task<IActionResult> SearchForRecipes(string apiRoute)
        {
            var spoonacularRecipes = await httpClient.GetFromJsonAsync<SpoonacularRecipe[]>(apiRoute);
            var mappingService = new RecipeMappingService();
            var recipes = mappingService.MapTo(spoonacularRecipes);

            if (!recipes.Any())
                return null;

            context.Recipes.AddRange(recipes);
            context.SaveChanges();

            return Ok();
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
