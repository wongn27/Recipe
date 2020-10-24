using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe.Web.Data.Enums;

namespace Recipe.Web.Data.Models
{
    public class InTheFridgeRecipe
    {
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [StringLength(100)]
        public string CookingTime { get; set; }
        public string PictureUrl { get; set; }
        public string Cuisines { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string Steps { get; set; }
        public int CalorieCount { get; set; }
        public int Servings { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsDairyFree { get; set; }
        public bool IsPopular { get; set; }
        public bool IsCheap { get; set; }
        public bool IsHealthy { get; set; }
        public bool IsSustainable { get; set; }

    }
}