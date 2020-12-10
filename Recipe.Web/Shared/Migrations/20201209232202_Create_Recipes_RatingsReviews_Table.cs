using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class Create_Recipes_RatingsReviews_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FridgeIngredient_Users_UserId",
                table: "Users_FridgeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_Users_FridgeIngredient_UserId",
                table: "Users_FridgeIngredient");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Users_FridgeIngredient",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Recipes_RatingsReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes_RatingsReviews", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes_RatingsReviews");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Users_FridgeIngredient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FridgeIngredient_UserId",
                table: "Users_FridgeIngredient",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FridgeIngredient_Users_UserId",
                table: "Users_FridgeIngredient",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
