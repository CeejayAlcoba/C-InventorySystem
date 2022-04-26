using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class FixSalesOrderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_SalesOrders_SalesOrderItemId",
                table: "SalesOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrderItems_SalesOrderItemId",
                table: "SalesOrderItems");

            migrationBuilder.DropColumn(
                name: "SalesOrderItemId",
                table: "SalesOrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesOrderItemId",
                table: "SalesOrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_SalesOrderItemId",
                table: "SalesOrderItems",
                column: "SalesOrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_SalesOrders_SalesOrderItemId",
                table: "SalesOrderItems",
                column: "SalesOrderItemId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
