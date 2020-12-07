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
    [Route("api/userFridgeIng")]
    [ApiController]
    public class UserFridgeIngredientController : ControllerBase
    {
        private readonly RecipeContext _context;
        public UserFridgeIngredientController(RecipeContext context)
        {
            this._context = context;
        }

        //GET - Get all the ingredients stored in the context - RT
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var fridgeIngredients = await _context.Users_FridgeIngredient.ToListAsync();
            return Ok(fridgeIngredients);
        }


        //GET - Get all ingredient stored in the context based on user Guid - RT
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var fridgeIngs = await _context.Users_FridgeIngredient.Where(a => a.UserId == id).ToListAsync();
            return Ok(fridgeIngs);
        }

        //Creates a new Ingredient with the passed object data - RT
        [HttpPost]
        public async Task<IActionResult> Post(UserFridgeIngredient userIngredient)
        {
            _context.Add(userIngredient);
            await _context.SaveChangesAsync();
            return Ok(userIngredient.Id);
        }

        //UPDATE - Modifies an existing Ingredient record - RT
        [HttpPut]
        public async Task<IActionResult> Put(UserFridgeIngredient userIngredient)
        {
            _context.Entry(userIngredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE - Deletes a ingredient record by Name - RT
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userIngredient = new UserFridgeIngredient { Id = id };
            _context.Remove(userIngredient);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
