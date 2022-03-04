using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Data.Migrations
{
    public partial class UpdateDB_RenameTable_Cart_To_Invoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_CreatorId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_UserId",
                table: "Cart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId",
                table: "Invoices",
                newName: "IX_Invoices_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_ProductId",
                table: "Invoices",
                newName: "IX_Invoices_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_CreatorId",
                table: "Invoices",
                newName: "IX_Invoices_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(3079), new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(3086) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(3559), new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(3562) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(3574), new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(3576) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(3937), new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(3941) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(4493), new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(4496) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(4514), new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(4515) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(4516), new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(4517) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(4519), new DateTime(2022, 3, 4, 15, 52, 40, 348, DateTimeKind.Local).AddTicks(4519) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 52, 40, 346, DateTimeKind.Local).AddTicks(9946), new DateTime(2022, 3, 4, 15, 52, 40, 347, DateTimeKind.Local).AddTicks(5482) });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Products_ProductId",
                table: "Invoices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_CreatorId",
                table: "Invoices",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Products_ProductId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_CreatorId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_UserId",
                table: "Cart",
                newName: "IX_Cart_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ProductId",
                table: "Cart",
                newName: "IX_Cart_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_CreatorId",
                table: "Cart",
                newName: "IX_Cart_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "InvoiceId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2434), new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2441) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2919), new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2923) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2934), new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(2935) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3289), new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3292) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3856), new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3877), new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3878) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3879), new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3881), new DateTime(2022, 3, 4, 15, 50, 13, 841, DateTimeKind.Local).AddTicks(3882) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 50, 13, 839, DateTimeKind.Local).AddTicks(8870), new DateTime(2022, 3, 4, 15, 50, 13, 840, DateTimeKind.Local).AddTicks(4523) });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_CreatorId",
                table: "Cart",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
