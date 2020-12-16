using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //GET - Get all UserRecipePosts stored in the context based on user Guid - RT
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var fridgeRecipe = await _context.Users_RecipePost.Where(a => a.UserId == id).ToListAsync();
            return Ok(fridgeRecipe);
        }

        //GET - Get all UserRecipePosts stored in the context based on user Guid - RT
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(Guid id)
        {
            var fridgeRecipe = await _context.Users_RecipePost.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(fridgeRecipe);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fridgeRecipe = await _context.Users_RecipePost.ToListAsync();
            return Ok(fridgeRecipe);
        }
    }
}