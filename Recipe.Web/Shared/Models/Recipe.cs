using Recipe.Web.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class Recipe
    {
        public int id { get; set; }
        public string title { get; set; }
        public string generatedText { get; set; }
        public Cuisine cuisine { get; set; }
        public int ingredientId { get; set; }
    }
}
