using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class Shopping_RecipePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RecipePost_Recipes_InTheFridgeRecipeId",
                table: "Users_RecipePost");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RecipePost_Users_UserId",
                table: "Users_RecipePost");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ShoppingList_Users_UserId",
                table: "Users_ShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_Users_ShoppingList_UserId",
                table: "Users_ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_RecipePost",
                table: "Users_RecipePost");

            migrationBuilder.DropIndex(
                name: "IX_Users_RecipePost_InTheFridgeRecipeId",
                table: "Users_RecipePost");

            migrationBuilder.DropIndex(
                name: "IX_Users_RecipePost_UserId",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "InTheFridgeRecipeId",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Users_RecipePost");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Users_ShoppingList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalorieCount",
                table: "Users_RecipePost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDairyFree",
                table: "Users_RecipePost",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGlutenFree",
                table: "Users_RecipePost",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHealthy",
                table: "Users_RecipePost",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVegan",
                table: "Users_RecipePost",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVegetarian",
                table: "Users_RecipePost",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Servings",
                table: "Users_RecipePost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_RecipePost",
                table: "Users_RecipePost",
                columns: new[] { "Id", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_RecipePost",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "CalorieCount",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "IsDairyFree",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "IsGlutenFree",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "IsHealthy",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "IsVegan",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "IsVegetarian",
                table: "Users_RecipePost");

            migrationBuilder.DropColumn(
                name: "Servings",
                table: "Users_RecipePost");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Users_ShoppingList",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "InTheFridgeRecipeId",
                table: "Users_RecipePost",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Users_RecipePost",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Users_RecipePost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_RecipePost",
                table: "Users_RecipePost",
                columns: new[] { "Id", "InTheFridgeRecipeId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ShoppingList_UserId",
                table: "Users_ShoppingList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecipePost_InTheFridgeRecipeId",
                table: "Users_RecipePost",
                column: "InTheFridgeRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecipePost_UserId",
                table: "Users_RecipePost",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RecipePost_Recipes_InTheFridgeRecipeId",
                table: "Users_RecipePost",
                column: "InTheFridgeRecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RecipePost_Users_UserId",
                table: "Users_RecipePost",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ShoppingList_Users_UserId",
                table: "Users_ShoppingList",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
