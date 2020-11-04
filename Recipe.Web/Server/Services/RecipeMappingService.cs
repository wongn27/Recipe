using System.Collections.Generic;
using System.Linq;
using Recipe.Web.Data.Models;

namespace Recipe.Web.Server.Services
{
    public class RecipeMappingService
    {
        public InTheFridgeRecipe MapSpoonacularRecipeToInTheFridgeRecipe(InTheFridgeRecipe original, SpoonacularRecipe spoon)
        {
            original.Name = spoon.Title;
            original.Description = spoon.Summary;
            original.CookingTime = spoon.CookingMinutes.HasValue ? $"{spoon.CookingMinutes.Value.ToString()} minutes" : "N/A";
            original.PictureUrl = spoon.Image;

            var ingredients = spoon.ExtendedIngredients
                .Where(i => !string.IsNullOrWhiteSpace(i.OriginalString))
                .Select(i => i.OriginalString.Replace(';', ','));

            original.Ingredients = string.Join(';', ingredients);

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

            original.Steps = string.Join(';', stepList);
            var steps = original.Steps.Split(';');

            // do the rest of the properties for InTheFridgeRecipe
            return original;
        }

    }
}
