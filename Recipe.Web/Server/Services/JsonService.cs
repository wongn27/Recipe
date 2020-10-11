using System;
using System.Text.Json;
using Recipe.Web.Data.Enums;
using Recipe.Web.Data.Models;

namespace Recipe.Web.Server.Services
{
    public static class JsonService
    {
        public static T DeserializeFrom<T>(InTheFridgeRecipe inTheFridgeRecipe)
            where T : class, new()
        {
            switch (inTheFridgeRecipe.ApiSourceName)
            {
                case RecipeApiSource.Original:
                {
                    throw new Exception($"This is an original recipe, and cannot be deserialized into a {typeof(T).Name}.");
                }
                default:
                    return JsonSerializer.Deserialize<T>(inTheFridgeRecipe.ApiJson);
            }
        }
    }
}
