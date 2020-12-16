using Recipe.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Web.Data.Extensions
{
    public static class InTheFridgeRecipeExtensions
    {
        public static bool IsTheSameRecipe(this InTheFridgeRecipe recipe, SpoonacularRecipe spoonRecipe)
        {
            // criteria for being the same recipe - Name, and desc
            return recipe.Name.Equals(spoonRecipe.Title, StringComparison.OrdinalIgnoreCase) &&
                   recipe.Description.Equals(spoonRecipe.Summary, StringComparison.OrdinalIgnoreCase);
        }
    }
}
