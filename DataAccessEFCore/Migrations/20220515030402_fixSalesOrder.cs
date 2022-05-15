using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class fixSalesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "SalesOrders",
                newName: "DefaultDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SalesOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "SalesOrders");

            migrationBuilder.RenameColumn(
                name: "DefaultDate",
                table: "SalesOrders",
                newName: "OrderDate");
        }
    }
}
