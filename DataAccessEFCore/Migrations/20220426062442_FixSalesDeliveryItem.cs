using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class FixSalesDeliveryItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesDeliveryItems",
                table: "SalesDeliveryItems");

            migrationBuilder.AddColumn<int>(
                name: "SalesDeliveryItemId",
                table: "SalesDeliveryItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesDeliveryItems",
                table: "SalesDeliveryItems",
                column: "SalesDeliveryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDeliveryItems_SalesDeliveryId",
                table: "SalesDeliveryItems",
                column: "SalesDeliveryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesDeliveryItems",
                table: "SalesDeliveryItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesDeliveryItems_SalesDeliveryId",
                table: "SalesDeliveryItems");

            migrationBuilder.DropColumn(
                name: "SalesDeliveryItemId",
                table: "SalesDeliveryItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesDeliveryItems",
                table: "SalesDeliveryItems",
                column: "SalesDeliveryId");
        }
    }
}
