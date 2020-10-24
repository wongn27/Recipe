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
        [StringLength(100)]
        public string CookingTime { get; set; }

        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
    }
}