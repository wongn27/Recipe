using System;
using System.Collections.Generic;
using System.Linq;
using Recipe.Web.Data.Models;

namespace Recipe.Web.Server.Services
{
    public class RecipeMappingService
    {
        public IEnumerable<InTheFridgeRecipe> MapTo(IEnumerable<SpoonacularRecipe> spoonacularRecipes)
        {
            foreach (var spoon in spoonacularRecipes)
                yield return MapTo(spoon);
        }

        public InTheFridgeRecipe MapTo(SpoonacularRecipe spoon)
        {
            var inTheFridgeRecipe = new InTheFridgeRecipe
            {
                Id = Guid.NewGuid(),
                Name = spoon.Title,
                Description = spoon.Summary,
                CookingTime = spoon.CookingMinutes.HasValue ? $"{spoon.CookingMinutes.Value} minutes" : "N/A",
                PictureUrl = spoon.Image,
                DateAdded = DateTime.Now,
                CalorieCount = 0,
                IsCheap = spoon.Cheap,
                IsDairyFree = spoon.DairyFree,
                IsGlutenFree = spoon.GlutenFree,
                IsHealthy = spoon.VeryHealthy,
                IsPopular = spoon.VeryPopular,
                IsSustainable = spoon.Sustainable,
                IsVegan = spoon.Vegan,
                IsVegetarian = spoon.Vegetarian,
                Rating = (float)spoon.HealthScore,
                Cuisines = string.Join(", ", spoon.Cuisines),
                Servings = (int)spoon.Servings,
            };

            var ingredients = spoon.ExtendedIngredients
                .Where(i => !string.IsNullOrWhiteSpace(i.OriginalString))
                .Select(i => i.OriginalString.Replace(';', ','));

            inTheFridgeRecipe.Ingredients = string.Join(';', ingredients);

            var stepList = new List<string>();
            for (int i = 0; i < spoon.AnalyzedInstructions.Length; i++)
            {
                var instr = spoon.AnalyzedInstructions[i];
                foreach (var step in instr.Steps)
                {
                    if (!string.IsNullOrWhiteSpace(step.OriginalStep))
                        stepList.Add(step.OriginalStep.Replace(';', ','));
                }
            }

            inTheFridgeRecipe.Steps = string.Join(';', stepList);
            inTheFridgeRecipe.Instructions = spoon.Instructions;

            var steps = inTheFridgeRecipe.Steps.Split(';');

            // do the rest of the properties for InTheFridgeRecipe

            return inTheFridgeRecipe;
        }

    }
}
