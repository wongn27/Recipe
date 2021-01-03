using System;
using System.Text.Json.Serialization;

namespace Recipe.Web.Data.Models
{
    public class SpoonacularRecipeComplexSearchResponse
    {
        [JsonPropertyName("results")]
        public Result[] Results { get; set; }

        [JsonPropertyName("offset")]
        public long Offset { get; set; }

        [JsonPropertyName("number")]
        public long Number { get; set; }

        [JsonPropertyName("totalResults")]
        public long TotalResults { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("image")]
        public Uri Image { get; set; }

        [JsonPropertyName("imageType")]
        public string ImageType { get; set; }
    }
}
