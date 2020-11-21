using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class Add_Ingredient_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_InTheFridgeRecipeId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_InTheFridgeRecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "InTheFridgeRecipeId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "InTheFridgeIngredientId",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InTheFridgeIngredientId",
                table: "Ingredients");

            migrationBuilder.AddColumn<Guid>(
                name: "InTheFridgeRecipeId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_InTheFridgeRecipeId",
                table: "Ingredients",
                column: "InTheFridgeRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_InTheFridgeRecipeId",
                table: "Ingredients",
                column: "InTheFridgeRecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
