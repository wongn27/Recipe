using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Recipe.Web.Data.Models;

namespace Recipe.Web.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var length = new Length()
            {
                Number = 10,
                Unit = "m"
            };

            var actualLength = length.Number + length.Unit;
        }

        public InTheFridgeRecipe ToRecipe(SpoonacularRecipe spoonRecipe)
        {
            var recipe = new InTheFridgeRecipe();

            // Map same property types (bool) to the corresponding Recipe property. 
            // Notice the slight difference in the name.

            //recipe.IsDairyFree = spoonRecipe.DairyFree;
            //recipe.IsVegetarian = spoonRecipe.Vegetarian;
            //recipe.IsVegan = spoonRecipe.Vegan;
            //recipe.IsGlutenFree = spoonRecipe.GlutenFree;

            // spoonRecipe.ExtendedIngredients is of type ExtendedIngredients[] and 
            // is a complex type.
            // We serialize its entire object into json and store the json.
            var extendedIngredientsJson = JsonSerializer.Serialize(spoonRecipe.ExtendedIngredients);
            //recipe.Spoon_ExtendedIngredients = extendedIngredientsJson;

            // Do for other complex types.

            return recipe;
        }

public ExtendedIngredient[] ToSpoon_ExtendedIngredients(string spoon_ExtendedIngredients)
{
    // Takes the stored recipe.Spoon_ExtendedIngredients 
    // JSON and turns it back into a ExtendedIngredient[] instance.
    var extendedIngredientsJson = JsonSerializer.Deserialize<ExtendedIngredient[]>(spoon_ExtendedIngredients);

    return extendedIngredientsJson;
}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
