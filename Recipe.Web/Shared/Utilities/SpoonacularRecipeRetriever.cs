using Recipe.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Recipe.Web.Data.Utilities
{
    public class SpoonacularRecipeRetriever
    {
        private readonly SpoonacularApiEndpointBuilder builder;
        private readonly HttpClient httpClient;

        public SpoonacularRecipeRetriever(SpoonacularApiEndpointBuilder builder, HttpClient httpClient)
        {
            this.builder = builder;
            this.httpClient = httpClient;
        }

        public SpoonacularRecipe[] Search(SpoonacularRecipeSearchModel searchModel)
        {
            return null;
            builder.AddParameter<string>("query", searchModel.SearchString);
            builder.AddParameter<int>("number", searchModel.NumberOfResults);

            var listOfIntolerances = new List<string>();

            if (searchModel.IsDairyFree)
                listOfIntolerances.Add("Dairy");

            if (searchModel.IsGlutenFree)
                listOfIntolerances.Add("Gluten");

            if (searchModel.IsVegetarian)
                listOfIntolerances.Add("Vegetarian");

            if (listOfIntolerances.Any())
                builder.AddParameters("intolerances", ",", listOfIntolerances.ToArray());

            var requestUrl = builder.BuildEndpoint();
            //var complexSearchResults = httpClient.GetFromJsonAsync<SpoonacularRecipe[]>(requestUrl);
        }

    }
}
