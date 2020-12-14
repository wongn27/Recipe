using Recipe.Web.Data.Models;
using Recipe.Web.Data.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Recipe.Web.Data.Utilities
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

    public class SpoonacularApiEndpointBuilder
    {
        // Key: Spoonacular Enum
        // Value: ApiEndpoint
        private Dictionary<SpoonacularApiEndpoint, ApiEndpoint> endpointsDictionary;
        private readonly SpoonacularApiEndpoint endpoint;

        public SpoonacularApiEndpointBuilder(SpoonacularApiEndpoint endpoint)
        {
            this.endpoint = endpoint;
            endpointsDictionary = new Dictionary<SpoonacularApiEndpoint, ApiEndpoint>();
            InitializeDictionary();
        }

        private void InitializeDictionary()
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
        public void AddId(int id)
        {
            endpointsDictionary.First(e => e.Key == endpoint).Value.BaseEndpointUrl.Replace("{id}", id.ToString());
        }

        public void AddIds(int[] ids)
        {
            var joinedIds = string.Join(',', ids);
            endpointsDictionary.First(e => e.Key == endpoint).Value.EndpointParams.Add($"ids={joinedIds}");
        }

        /// <summary>
        /// Add a parameter to a <see cref="SpoonacularApiEndpoint"/>.
        /// </summary>
        /// <typeparam name="T">The type of parameter needed.</typeparam>
        /// <param name="parameterName"></param>
        /// <param name="value">The value of <see cref="T"/>.</param>
        public void AddParameter<T>(string parameterName, T value)
        {
            endpointsDictionary.First(e => e.Key == endpoint).Value.EndpointParams.Add($"{parameterName}={value}");
        }

        /// <summary>
        /// Adds a delimited multi-variable parameter.
        /// </summary>
        /// <param name="parameterName">The name of the parameter for the endpoint.</param>
        /// <param name="parameterDelimiter">The delmiter</param>
        /// <param name="values">A string sequence of values.</param>
        public void AddParameters(string parameterName, string parameterDelimiter, params string[] values)
        {
            var parameters = string.Join(parameterDelimiter, values);
            AddParameter(parameterName, parameters);
        }

        public string GetBaseEndpointFrom()
        {
            return endpointsDictionary
                .First(e => e.Key == endpoint)
                .Value
                .BaseEndpointUrl;
        }

        public List<string> GetEndpointParameters()
        {
            return endpointsDictionary
                .First(e => e.Key == endpoint)
                .Value
                .EndpointParams;
        }

        public string BuildEndpoint()
        {
            var baseUrl = GetBaseEndpointFrom();
            var parameters = GetEndpointParameters();

            if (parameters.Any() && !baseUrl.EndsWith("?"))
                baseUrl += "?";

            var joinedParameters = string.Join('&', parameters);
            var endpointToReturn = $"{baseUrl}{joinedParameters}&apiKey={SpoonacularApiKey.ApiKey}";

            return endpointToReturn;
        }
    }
}
