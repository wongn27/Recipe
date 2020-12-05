using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Web.Data;
using Recipe.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Web.Server.Controllers
{
    [Route("api/userRecipeController")]
    [ApiController]
    public class UserRecipeController : ControllerBase
    {
        private RecipeContext _context;
        public UserRecipeController(RecipeContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRecipePost recipe)
        {
            _context.Users_RecipePost.Attach(recipe);
            _context.Add(recipe);
            await _context.SaveChangesAsync();
            return Ok(recipe.Id);
        }
    }
}