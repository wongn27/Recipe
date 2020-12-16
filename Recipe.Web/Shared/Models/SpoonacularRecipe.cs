using System.Text.Json.Serialization;

namespace Recipe.Web.Data.Models
{
    
    public class SpoonacularRecipe
    {
        
        [JsonPropertyName("vegetarian")]
        public bool Vegetarian { get; set; }

        [JsonPropertyName("vegan")]
        public bool Vegan { get; set; }

        [JsonPropertyName("glutenFree")]
        public bool GlutenFree { get; set; }

        [JsonPropertyName("dairyFree")]
        public bool DairyFree { get; set; }

        [JsonPropertyName("veryHealthy")]
        public bool VeryHealthy { get; set; }

        [JsonPropertyName("cheap")]
        public bool Cheap { get; set; }

        [JsonPropertyName("veryPopular")]
        public bool VeryPopular { get; set; }

        [JsonPropertyName("sustainable")]
        public bool Sustainable { get; set; }

        [JsonPropertyName("weightWatcherSmartPoints")]
        public long WeightWatcherSmartPoints { get; set; }

        [JsonPropertyName("gaps")]
        public string Gaps { get; set; }

        [JsonPropertyName("lowFodmap")]
        public bool LowFodmap { get; set; }

        [JsonPropertyName("preparationMinutes")]
        public long? PreparationMinutes { get; set; }

        [JsonPropertyName("cookingMinutes")]
        public long? CookingMinutes { get; set; }

        [JsonPropertyName("aggregateLikes")]
        public long AggregateLikes { get; set; }

        [JsonPropertyName("spoonacularScore")]
        public double SpoonacularScore { get; set; }

        [JsonPropertyName("healthScore")]
        public double HealthScore { get; set; }

        [JsonPropertyName("creditsText")]
        public string CreditsText { get; set; }

        [JsonPropertyName("license")]
        public string License { get; set; }

        [JsonPropertyName("sourceName")]
        public string SourceName { get; set; }

        [JsonPropertyName("pricePerServing")]
        public double PricePerServing { get; set; }

        [JsonPropertyName("extendedIngredients")]
        public ExtendedIngredient[] ExtendedIngredients { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("readyInMinutes")]
        public long ReadyInMinutes { get; set; }

        [JsonPropertyName("servings")]
        public long Servings { get; set; }

        [JsonPropertyName("sourceUrl")]
        public string SourceUrl { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("imageType")]
        public string ImageType { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("cuisines")]
        public string[] Cuisines { get; set; }

        [JsonPropertyName("dishTypes")]
        public string[] DishTypes { get; set; }

        // TODO Diets
        [JsonPropertyName("diets")]
        public object[] Diets { get; set; }

        // TODO Occasions
        [JsonPropertyName("occasions")]
        public object[] Occasions { get; set; }

        [JsonPropertyName("winePairing")]
        public WinePairing WinePairing { get; set; }

        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }

        [JsonPropertyName("analyzedInstructions")]
        public AnalyzedInstruction[] AnalyzedInstructions { get; set; }

        [JsonPropertyName("spoonacularSourceUrl")]
        public string SpoonacularSourceUrl { get; set; }
    }

    public class AnalyzedInstruction
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("steps")]
        public Step[] Steps { get; set; }
    }

    public class Step
    {
        [JsonPropertyName("number")]
        public long Number { get; set; }

        [JsonPropertyName("step")]
        public string OriginalStep { get; set; }

        [JsonPropertyName("ingredients")]
        public StepsIngredients[] Ingredients { get; set; }

        [JsonPropertyName("equipment")]
        public StepsEquipment[] Equipment { get; set; }

        [JsonPropertyName("length")]
        public Length Length { get; set; }
    }

    public class StepsIngredients
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }

    public class StepsEquipment
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }

    public class Length
    {
        [JsonPropertyName("number")]
        public long Number { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }

    public class ExtendedIngredient
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("aisle")]
        public string Aisle { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("consistency")]
        public string Consistency { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("original")]
        public string Original { get; set; }

        [JsonPropertyName("originalString")]
        public string OriginalString { get; set; }

        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("meta")]
        public string[] Meta { get; set; }

        [JsonPropertyName("metaInformation")]
        public string[] MetaInformation { get; set; }

        [JsonPropertyName("measures")]
        public Measures Measures { get; set; }
    }

    public class Measures
    {
        [JsonPropertyName("us")]
        public Metric Us { get; set; }

        [JsonPropertyName("metric")]
        public Metric Metric { get; set; }
    }

    public class Metric
    {
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("unitShort")]
        public string UnitShort { get; set; }

        [JsonPropertyName("unitLong")]
        public string UnitLong { get; set; }
    }

    public class WinePairing
    {
        [JsonPropertyName("pairedWines")]
        public string[] PairedWines { get; set; }

        [JsonPropertyName("pairingText")]
        public string PairingText { get; set; }

        [JsonPropertyName("productMatches")]
        public ProductMatch[] ProductMatches { get; set; }
    }

    public class ProductMatch
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("averageRating")]
        public double AverageRating { get; set; }

        [JsonPropertyName("ratingCount")]
        public long RatingCount { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
    
}