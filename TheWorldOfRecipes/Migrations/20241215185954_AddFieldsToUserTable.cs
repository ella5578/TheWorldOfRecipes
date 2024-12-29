using System;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TheWorldOfRecipes.Migrations
{
    public partial class AddFieldsToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // הוספת שדה FirstName
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            // הוספת שדה LastName
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            // הוספת שדה RegistrationDate
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.UtcNow); // הגדרת ערך ברירת מחדל
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // מחיקת שדה FirstName
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            // מחיקת שדה LastName
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            // מחיקת שדה RegistrationDate
            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "User");
        }
    }
}
