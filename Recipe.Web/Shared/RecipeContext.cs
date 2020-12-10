using Microsoft.EntityFrameworkCore;
using Recipe.Web.Data.Models;
using System.Security.Cryptography.X509Certificates;

namespace Recipe.Web.Data
{
    public class RecipeContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=tcp:recipe-fsc.database.windows.net,1433;Initial Catalog=recipe;Persist Security Info=False;User ID=wongnatmei@gmail.com@recipe-fsc;Password=Twocashews$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRecipePost>()
                .HasKey(x => new { x.Id, x.UserId });
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<InTheFridgeRecipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<UserRecipePost> Users_RecipePost { get; set; }
        public DbSet<UserFridgeIngredient> Users_FridgeIngredient { get; set; }
        public DbSet<UserShoppingList> Users_ShoppingList { get; set; }
        public DbSet<RecipeRatingReview> Recipes_RatingsReviews { get; set; }
    }
}
