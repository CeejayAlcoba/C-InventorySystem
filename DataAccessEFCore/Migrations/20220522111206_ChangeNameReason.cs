using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class ChangeNameReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnReason",
                table: "SalesOrders",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "ReturnReason",
                table: "PurchaseOrders",
                newName: "Reason");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "SalesOrders",
                newName: "ReturnReason");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "PurchaseOrders",
                newName: "ReturnReason");
        }
    }
}
