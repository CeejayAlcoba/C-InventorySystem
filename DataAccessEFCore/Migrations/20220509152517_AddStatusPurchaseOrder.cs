using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class AddStatusPurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "PurchaseOrders");
        }
    }
}
