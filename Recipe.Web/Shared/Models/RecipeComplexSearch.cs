using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Web.Data.Models
{
    // https://api.spoonacular.com/recipes/complexSearch?addRecipeInformation=true&number=1&apiKey=d36cb53813e341069b3c81d6d3b61c31

    public class RecipeComplexSearch
    {
        public RecipeResults[] results { get; set; }
        public int offset { get; set; }
        public int number { get; set; }
        public int totalResults { get; set; }
    }

    public class RecipeResults
    {
        public bool vegetarian { get; set; }
        public bool vegan { get; set; }
        public bool glutenFree { get; set; }
        public bool dairyFree { get; set; }
        public bool veryHealthy { get; set; }
        public bool cheap { get; set; }
        public bool veryPopular { get; set; }
        public bool sustainable { get; set; }
        public int weightWatcherSmartPoints { get; set; }
        public string gaps { get; set; }
        public bool lowFodmap { get; set; }
        public int aggregateLikes { get; set; }
        public float spoonacularScore { get; set; }
        public float healthScore { get; set; }
        public string creditsText { get; set; }
        public string license { get; set; }
        public string sourceName { get; set; }
        public float pricePerServing { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public string summary { get; set; }
        public string[] cuisines { get; set; }
        public string[] dishTypes { get; set; }
        public string[] diets { get; set; }
        public object[] occasions { get; set; }
        public Analyzedinstruction3[] analyzedInstructions { get; set; }
        public string spoonacularSourceUrl { get; set; }
    }

    public class Analyzedinstruction3
    {
        public string name { get; set; }
        public Step3[] steps { get; set; }
    }

    public class Step3
    {
        public int number { get; set; }
        public string step { get; set; }
        public Ingredient3[] ingredients { get; set; }
        public Equipment3[] equipment { get; set; }
        public Length3 length { get; set; }
    }

    public class Length3
    {
        public int number { get; set; }
        public string unit { get; set; }
    }

    public class Ingredient3
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
    }

    public class Equipment3
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
    }

    // }
}
