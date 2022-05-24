using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class AddFeignkeyInProductHistpry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductHistories");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "ProductHistories",
                newName: "IsActive");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderId",
                table: "ProductHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesOrderId",
                table: "ProductHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistories_PurchaseOrderId",
                table: "ProductHistories",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistories_SalesOrderId",
                table: "ProductHistories",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHistories_PurchaseOrders_PurchaseOrderId",
                table: "ProductHistories",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHistories_SalesOrders_SalesOrderId",
                table: "ProductHistories",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHistories_PurchaseOrders_PurchaseOrderId",
                table: "ProductHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductHistories_SalesOrders_SalesOrderId",
                table: "ProductHistories");

            migrationBuilder.DropIndex(
                name: "IX_ProductHistories_PurchaseOrderId",
                table: "ProductHistories");

            migrationBuilder.DropIndex(
                name: "IX_ProductHistories_SalesOrderId",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderId",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "SalesOrderId",
                table: "ProductHistories");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ProductHistories",
                newName: "IsDelete");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ProductHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ProductHistories",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Open");
        }
    }
}
