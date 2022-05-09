using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class fixStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "PurchaseOrders",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Open",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PurchaseOrders",
                newName: "status");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Open");
        }
    }
}
