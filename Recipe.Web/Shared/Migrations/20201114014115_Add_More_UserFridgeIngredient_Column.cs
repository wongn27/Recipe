using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class Add_More_UserFridgeIngredient_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Users_FridgeIngredient",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Users_FridgeIngredient");
        }
    }
}
