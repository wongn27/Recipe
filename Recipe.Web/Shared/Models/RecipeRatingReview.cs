using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class RecipeRatingReview
    {
        public Guid Id { get; set; }
        public Guid InTheFridgeRecipeId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
