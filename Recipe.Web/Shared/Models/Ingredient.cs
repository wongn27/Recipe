using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class Ingredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photoPath { get; set; }
    }


    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string name { get; set; }
        public string image { get; set; }
        public int id { get; set; }
        public string aisle { get; set; }
        public string[] possibleUnits { get; set; }
    }

}
