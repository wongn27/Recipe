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


}
