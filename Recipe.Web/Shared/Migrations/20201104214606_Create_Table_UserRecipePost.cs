using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class Create_Table_UserRecipePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users_RecipePost",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InTheFridgeRecipeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<float>(nullable: true),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_RecipePost", x => new { x.Id, x.InTheFridgeRecipeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Users_RecipePost_Recipes_InTheFridgeRecipeId",
                        column: x => x.InTheFridgeRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_RecipePost_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecipePost_InTheFridgeRecipeId",
                table: "Users_RecipePost",
                column: "InTheFridgeRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecipePost_UserId",
                table: "Users_RecipePost",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_RecipePost");
        }
    }
}
