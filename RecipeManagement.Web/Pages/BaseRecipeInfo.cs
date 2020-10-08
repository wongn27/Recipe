using Microsoft.AspNetCore.Components;
using Recipe.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagement.Web.Pages
{

    public class BaseRecipeInfo : ComponentBase
    {
        public IEnumerable<Ingredient> Ingredients { get; set; }

        protected override Task OnInitializedAsync()
        {
            LoadIngredients();
            return base.OnInitializedAsync();
        }

        private void LoadIngredients()
        {
            Ingredient test1 = new Ingredient
            {
                id = 4204,
                name = "Onion",
                photoPath= "images/Onions.jpg"
            };

            Ingredient test2 = new Ingredient
            {
                id = 7635,
                name = "Milk",
                photoPath = "images/Milk.jpg"
            };

            Ingredient test3 = new Ingredient
            {
                id = 6534,
                name = "Carrot",
                photoPath = "images/Carrot.jpg"
            };

            Ingredients = new List<Ingredient> { test1, test2, test3 };
        }
    }
}
