using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class ShoppingListUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ShoppingList_Ingredients_IngredientId",
                table: "Users_ShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_Users_ShoppingList_IngredientId",
                table: "Users_ShoppingList");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Users_ShoppingList");

            migrationBuilder.AddColumn<string>(
                name: "IngredientName",
                table: "Users_ShoppingList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Users_ShoppingList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientName",
                table: "Users_ShoppingList");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Users_ShoppingList");

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientId",
                table: "Users_ShoppingList",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ShoppingList_IngredientId",
                table: "Users_ShoppingList",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RatingsReviews_RecipeId",
                table: "Recipes_RatingsReviews",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RatingsReviews_UserId",
                table: "Recipes_RatingsReviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ShoppingList_Ingredients_IngredientId",
                table: "Users_ShoppingList",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
