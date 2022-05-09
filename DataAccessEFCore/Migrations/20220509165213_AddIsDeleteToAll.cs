using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class AddIsDeleteToAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Uoms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Suppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Sizes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Shippers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SalesReturns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SalesOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SalesOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SalesOrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SalesDeliveries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SalesChannels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "PurchaseReturns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "PurchaseReceipts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "PurchaseOrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Locations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Colours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Uoms");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SalesReturns");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SalesOrderItems");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SalesDeliveries");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SalesChannels");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "PurchaseReturns");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Colours");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Brands");
        }
    }
}
