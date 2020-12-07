using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Web.Data.Models
{


    public class RootobjectRecipe
    {
        public RecipeTest[] results { get; set; }
        public int offset { get; set; }
        public int number { get; set; }
        public int totalResults { get; set; }
    }

    public class RecipeTest
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
    }


    public class RootobjectRandom
    {
        public RecipeRandom[] recipes { get; set; }
    }

    public class RecipeRandom
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
        public ExtendedingredientRandom[] extendedIngredients { get; set; }
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
        public string instructions { get; set; }
        public AnalyzedinstructionRandom[] analyzedInstructions { get; set; }
        public object originalId { get; set; }
        public string spoonacularSourceUrl { get; set; }
    }

    public class ExtendedingredientRandom
    {
        public int id { get; set; }
        public string aisle { get; set; }
        public string image { get; set; }
        public string consistency { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public string[] meta { get; set; }
        public string[] metaInformation { get; set; }
        public MeasuresRandom measures { get; set; }
    }

    public class MeasuresRandom
    {
        public UsRandom us { get; set; }
        public MetricRandom metric { get; set; }
    }

    public class UsRandom
    {
        public float amount { get; set; }
        public string unitShort { get; set; }
        public string unitLong { get; set; }
    }

    public class MetricRandom
    {
        public float amount { get; set; }
        public string unitShort { get; set; }
        public string unitLong { get; set; }
    }

    public class AnalyzedinstructionRandom
    {
        public string name { get; set; }
        public StepRandom[] steps { get; set; }
    }

    public class StepRandom
    {
        public int number { get; set; }
        public string step { get; set; }
        public IngredientRandom[] ingredients { get; set; }
        public EquipmentRandom[] equipment { get; set; }
        public LengthRandom length { get; set; }
    }

    public class LengthRandom
    {
        public int number { get; set; }
        public string unit { get; set; }
    }

    public class IngredientRandom
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
    }

    public class EquipmentRandom
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
    }


    public class FunFact
    {
        public string text { get; set; }
    }






}
