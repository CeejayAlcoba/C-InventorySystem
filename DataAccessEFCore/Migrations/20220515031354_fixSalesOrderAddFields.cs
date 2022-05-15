using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class fixSalesOrderAddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BeforeTax",
                table: "SalesOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "SalesOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OtherCharge",
                table: "SalesOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SubTotal",
                table: "SalesOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TaxAmount",
                table: "SalesOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "SalesOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeforeTax",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "OtherCharge",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "SalesOrders");
        }
    }
}
