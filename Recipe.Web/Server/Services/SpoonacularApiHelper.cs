using Recipe.Web.Data.Models;
using Recipe.Web.Data.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Recipe.Web.Server.Services
{

    public enum SpoonacularApiEndpoint
    {
        ComplexSearch,
        FindByIngredients,
        FindByNutrients,
        RecipeById,
        BulkRecipeByIds,
        InstructionsById
    }

    public class SpoonacularApiHelper
    {
        // Key: Spoonacular Enum
        // Value: ApiEndpoint
        private Dictionary<SpoonacularApiEndpoint, ApiEndpoint> endpointsDictionary;

        public SpoonacularApiHelper()
        {
            endpointsDictionary.Add(SpoonacularApiEndpoint.ComplexSearch, new ApiEndpoint("https://api.spoonacular.com/recipes/complexSearch?"));
            endpointsDictionary.Add(SpoonacularApiEndpoint.FindByIngredients, new ApiEndpoint("https://api.spoonacular.com/recipes/findByIngredients?"));
            endpointsDictionary.Add(SpoonacularApiEndpoint.FindByNutrients, new ApiEndpoint("https://api.spoonacular.com/recipes/findByNutrients?"));
            endpointsDictionary.Add(SpoonacularApiEndpoint.RecipeById, new ApiEndpoint("https://api.spoonacular.com/recipes/{id}/information"));
            endpointsDictionary.Add(SpoonacularApiEndpoint.BulkRecipeByIds, new ApiEndpoint("https://api.spoonacular.com/recipes/informationBulk?ids=715538,716429"));
            endpointsDictionary.Add(SpoonacularApiEndpoint.InstructionsById, new ApiEndpoint("https://api.spoonacular.com/recipes/{id}/analyzedInstructions?"));
        }

        /// <summary>
        /// Only for endpoints that have a {id} in their base url.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="id"></param>
        public void AddId(SpoonacularApiEndpoint endpoint, int id)
        {
            endpointsDictionary.First(e => e.Key == endpoint).Value.BaseEndpointUrl.Replace("{id}", id.ToString());
        }

        public void AddIds(SpoonacularApiEndpoint endpoint, int[] ids)
        {
            var joinedIds = string.Join(',', ids);
            endpointsDictionary.First(e => e.Key == endpoint).Value.EndpointParams.Add($"ids={joinedIds}");
        }

        /// <summary>
        /// Add a parameter to a <see cref="SpoonacularApiEndpoint"/>.
        /// </summary>
        /// <typeparam name="T">The type of parameter needed.</typeparam>
        /// <param name="endpoint"></param>
        /// <param name="parameterName"></param>
        /// <param name="value">The value of <see cref="T"/>.</param>
        public void AddParameter<T>(SpoonacularApiEndpoint endpoint, string parameterName, T value)
        {
            endpointsDictionary.First(e => e.Key == endpoint).Value.EndpointParams.Add($"{parameterName}={value}");
        }

        public string GetBaseEndpointFrom(SpoonacularApiEndpoint endpoint)
        {
            return endpointsDictionary
                .First(e => e.Key == endpoint)
                .Value
                .BaseEndpointUrl;
        }

        public List<string> GetEndpointParameters(SpoonacularApiEndpoint endpoint)
        {
            return endpointsDictionary
                .First(e => e.Key == endpoint)
                .Value
                .EndpointParams;
        }

        public string BuildEndpoint(SpoonacularApiEndpoint endpoint)
        {
            var baseUrl = GetBaseEndpointFrom(endpoint);
            var parameters = GetEndpointParameters(endpoint);

            if (parameters.Any() && !baseUrl.EndsWith("?"))
                baseUrl += "?";

            var joinedParameters = string.Join('&', parameters);
            var endpointToReturn = $"{baseUrl}{joinedParameters}&apiKey={SpoonacularApiKey.ApiKey}";

            return endpointToReturn;
        }
    }
}
