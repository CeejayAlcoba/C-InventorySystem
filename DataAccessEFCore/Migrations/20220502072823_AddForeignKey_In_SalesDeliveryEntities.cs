using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class AddForeignKey_In_SalesDeliveryEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "SalesDeliveries");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "SalesDeliveries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDeliveries_LocationId",
                table: "SalesDeliveries",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDeliveries_Locations_LocationId",
                table: "SalesDeliveries",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDeliveries_Locations_LocationId",
                table: "SalesDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_SalesDeliveries_LocationId",
                table: "SalesDeliveries");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "SalesDeliveries");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SalesDeliveries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
