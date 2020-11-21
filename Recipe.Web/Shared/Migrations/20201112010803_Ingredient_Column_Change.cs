using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class Ingredient_Column_Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Ingredients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Ingredients");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Ingredients",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
