using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClientRecipe.Models
{

    public class IngredientList
    {
        public List<Ingredient> Ingredients { get; set; }
    }

    public class Ingredient
    {
        public string name { get; set; }
        public string image { get; set; }
        public int id { get; set; }
        public string aisle { get; set; }
        public string[] possibleUnits { get; set; }



        public List<Ingredient> GetAllIngredients(List<Ingredient> iL)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            IngredientList ingredientList = new IngredientList();
            Ingredient newIngredient = new Ingredient();

            for ( int i = 0; i < iL.Count; i++)
            {
                newIngredient.name = iL[i].name;
                newIngredient.image = iL[i].image;
                newIngredient.id = iL[i].id;
                ingredients.Add(newIngredient);                
            }
            ingredientList.Ingredients = ingredients;
            return ingredientList.Ingredients;
        }
    }

  

}
