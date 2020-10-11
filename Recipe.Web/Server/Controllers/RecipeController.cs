using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe.Web.Data;

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
    }
}
