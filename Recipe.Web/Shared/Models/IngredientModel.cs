using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Recipe.Web.Data.Models
{
    //https://spoonacular.com/food-api/docs#Autocomplete-Ingredient-Search - Site for reference - RT

    public class IngredientModel
    {
        public string name { get; set; }
        public string image { get; set; }
        public int id { get; set; }
        public string aisle { get; set; }
        public string[] possibleUnits { get; set; }
    }

    [DefaultBindingProperty]
    public class IngredientList : ObservableCollection<IngredientModel>
    {
        public IngredientList() //: base()
        {
            
        }
        public void OnGet()
        {
            
        }

 

    }

}
