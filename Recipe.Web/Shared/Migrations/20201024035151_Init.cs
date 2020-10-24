using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    CookingTime = table.Column<string>(maxLength: 100, nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Ingredients = table.Column<string>(nullable: true),
                    Steps = table.Column<string>(nullable: true),
                    ApiSourceName = table.Column<int>(nullable: false),
                    ApiJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    FailedLoginAttempts = table.Column<int>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    SecurityQuestion1 = table.Column<string>(maxLength: 100, nullable: false),
                    SecurityQuestion2 = table.Column<string>(maxLength: 100, nullable: false),
                    SecurityAnswer1 = table.Column<string>(maxLength: 100, nullable: false),
                    SecurityAnswer2 = table.Column<string>(maxLength: 100, nullable: false),
                    ProfilePicture = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Bio = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
