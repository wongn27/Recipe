using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string PictureUrl { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int InTheFridgeIngredientId { get; set; }
    }
}
