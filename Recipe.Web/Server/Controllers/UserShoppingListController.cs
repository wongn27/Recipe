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
    [Route("api/userShoppingListController")]
    [ApiController]
    public class UserShoppingListController : ControllerBase
    {
        private readonly RecipeContext _context;

        public UserShoppingListController(RecipeContext context)
        {
            this._context = context;
        }

        //GET - Get all the shopping list elements stored in the context - RT
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shoppingIngredients = await _context.Users_ShoppingList.ToListAsync();
            return Ok(shoppingIngredients);
        }


        //GET - Get all ingredient stored in shopping list based on user Guid - RT
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var shoppingList = await _context.Users_ShoppingList.Where(a => a.UserId == id).ToListAsync();
            return Ok(shoppingList);
        }

        //Posts a new Ingredient in the list for the passed object data - RT
        [HttpPost]
        public async Task<IActionResult> Post(UserShoppingList userIngredient)
        {
            _context.Add(userIngredient);
            await _context.SaveChangesAsync();
            return Ok(userIngredient);
        }

        //UPDATE - Modifies an existing Ingredient record - RT
        [HttpPut]
        public async Task<IActionResult> Put(UserShoppingList userIngredient)
        {
            _context.Entry(userIngredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //DELETE - Deletes a ingredient record by Name - RT
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userIngredient = _context.Users_ShoppingList.FirstOrDefault(s => s.Id.Equals(id));
            if (userIngredient == null)
            {
                return BadRequest();
            }
            _context.Remove(userIngredient);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
