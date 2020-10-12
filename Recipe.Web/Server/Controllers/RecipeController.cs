using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe.Web.Data;
using Recipe.Web.Data.Models;
using Recipe.Web.Server.Services;

namespace Recipe.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> logger;
        private readonly RecipeContext context;

        public RecipeController(ILogger<RecipeController> logger, RecipeContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public void Example()
        {
            var jsonResponse = "";
            var spoon = JsonSerializer.Deserialize<SpoonacularRecipe>(jsonResponse);
            var inTheFridgeRecipe = new InTheFridgeRecipe();
            var mappingService = new RecipeMappingService();
            inTheFridgeRecipe = mappingService.MapSpoonacularRecipeToInTheFridgeRecipe(inTheFridgeRecipe, spoon);
            context.Recipes.Add(inTheFridgeRecipe);
            context.SaveChanges();
        }
    }
}
