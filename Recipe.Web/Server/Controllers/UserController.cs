using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe.Web.Data;
using Recipe.Web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Web.Server
{
    [Route("api/userController")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RecipeContext _context;

        public UserController(RecipeContext context)
        {
            this._context = context;
        }


        //An Action method to get all the Users from the context instance. - RT
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ings = await _context.Users.ToListAsync();
            return Ok(ings);
        }

        //Fetches the details of one User that matches the passed email as parameter. - RT
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var ing = await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
            return Ok(ing);
        }

        //Creates a new User with the passed object data - RT *NOT TESTED*
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user.Id);
        }

        //Modifies an existing User record
        [HttpPut]
        public async Task<IActionResult> Put(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
