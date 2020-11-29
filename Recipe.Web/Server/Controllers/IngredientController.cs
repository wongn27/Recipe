using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe.Web.Data;
using Recipe.Web.Data.Models;

namespace Recipe.Web.Server.Controllers
{
    [Route("api/ingredientController")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly RecipeContext _context;

        public IngredientController(RecipeContext context)
        {
            this._context = context;
        }


        //An Action method to get all the Ingredients from the context instance. - RT
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ings = await _context.Ingredients.ToListAsync();
            return Ok(ings);
        }

        //Fetches the details of one INGREDIENT that matches the passed id as parameter. - RT
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ing = await _context.Ingredients.FirstOrDefaultAsync(a => a.InTheFridgeIngredientId == id);
            return Ok(ing);
        }

        //Creates a new Ingredient with the passed object data - RT
        [HttpPost]
        public async Task<IActionResult> Post(Ingredient ingredient)
        {
            _context.Add(ingredient);
            await _context.SaveChangesAsync();
            return Ok(ingredient.Id);
        }

        //Modifies an existing ingredient record
        [HttpPut]
        public async Task<IActionResult> Put(Ingredient ingredient)
        {
            _context.Entry(ingredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
