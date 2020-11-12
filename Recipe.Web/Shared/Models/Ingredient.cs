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
        public byte[] Picture { get; set; }
        [Required]
        public string Name { get; set; }
        //public int RecipeRefId { get; set; }
        //[ForeignKey("RecipeRefId")]
        //public InTheFridgeRecipe InTheFridgeRecipe { get; set; }

        //public int InTheFrigeRecipeId { get; set; }
        public InTheFridgeRecipe InTheFridgeRecipe { get; set; }

    }
}
