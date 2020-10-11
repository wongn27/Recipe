using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipe.Web.Data.Migrations
{
    public partial class Create_Users_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    FailedLoginAttempts = table.Column<int>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    SecurityQuestion1 = table.Column<string>(maxLength: 100, nullable: false),
                    SecurityQuestion2 = table.Column<string>(maxLength: 100, nullable: false),
                    SecurityAnswer1 = table.Column<string>(maxLength: 100, nullable: false),
                    SecurityAnswer2 = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
