using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class addSeedDataInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Firstname", "HashPassword", "Lastname", "Salt", "Username" },
                values: new object[] { 1, "Admin", "atlDQaBh6kcy9o7vKTRXiGT+FlGPYY/TFVdxYNC/vZc=", "Admin", new byte[] { 249, 236, 58, 10, 82, 10, 86, 138, 107, 114, 106, 181, 36, 201, 72, 244 }, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
