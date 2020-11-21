using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class Remove_Column_InTheFridgeRecipeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InTheFrigeRecipeId",
                table: "Ingredients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InTheFrigeRecipeId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
