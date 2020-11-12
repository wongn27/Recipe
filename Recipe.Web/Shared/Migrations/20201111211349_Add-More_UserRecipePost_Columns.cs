using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class AddMore_UserRecipePost_Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CookingTime",
                table: "Users_RecipePost",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Users_RecipePost",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Users_RecipePost",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Users_RecipePost",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Steps",
                table: "Users_RecipePost",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookingTime",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "Steps",
                table: "Users_RecipePost");
        }
    }
}
