using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class addIsDeletePurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "PurchaseOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PurchaseOrders");
        }
    }
}
