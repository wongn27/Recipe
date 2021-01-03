using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class SpoonacularRecipeSearchModel
    {
        public string SearchString { get; set; }
        public int NumberOfResults { get;  set; }
        public bool IsVegetarian { get; set; }
        public bool IsDairyFree { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}
