using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class AddNameSalesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SalesOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SalesOrders");
        }
    }
}
