using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class changeBeforeTotalIntoBeforeTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BeforeTotal",
                table: "PurchaseOrderItems",
                newName: "BeforeTax");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BeforeTax",
                table: "PurchaseOrderItems",
                newName: "BeforeTotal");
        }
    }
}
