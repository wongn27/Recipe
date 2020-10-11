using Microsoft.EntityFrameworkCore;
using Recipe.Web.Data.Models;

namespace Recipe.Web.Data
{
    public class RecipeContext : DbContext
    {
        private string password { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:recipe-fsc.database.windows.net,1433;Initial Catalog=recipe;Persist Security Info=False;User ID=wongnatmei@gmail.com@recipe-fsc;Password=Twocashews$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<InTheFridgeRecipe> Recipes { get; set; }
    }
}
