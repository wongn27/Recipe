using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class IngredientModel
    {
        public string name { get; set; }
        public string image { get; set; }
        public int id { get; set; }
        public string aisle { get; set; }
        public string[] possibleUnits { get; set; }
       
    }

    public class IngredientList : ObservableCollection<IngredientModel>
    {
        public IngredientList() //: base()
        {
            
        }

 

    }

}
