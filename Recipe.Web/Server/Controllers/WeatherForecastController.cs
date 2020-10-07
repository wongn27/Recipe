using Recipe.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe.Web.Data;
using Recipe.Web.Data.Utilities;
using System.Net.Http;
using System.Text.Json;

namespace Recipe.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;

            
            var context = new RecipeContext();
            // Whatever the password that is sent from the Create Account form. I will need to hash the password before I send it to Azure.
            var thepassword = "himan";
            context.Users.Add(new User() { Email = "", Password = StringHasher.Hash(thepassword), IsLocked = false });
            context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

       /* [HttpPost]
        public async Task<IActionResult> SearchApi(string searchQuery)
        {
            using var httpclient = new HttpClient();
            var response = await httpclient.GetAsync($"API/{searchQuery}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserialize the json into the Recipe API class.
            // JsonSerializer.Deserialize<RecipeClass>(jsonResponse);
            // map the RecipeAPI class tothe appropate Recipe class.

            // send this recipe model to the view

            // maybe with additional parameters to say it is not from the database, but an api.

            IsApi*/

        //}
    }
}
