using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Data.Migrations
{
    public partial class UpdateDB_AddTable_Invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Cart_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Cart_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CreatorId",
                table: "Cart",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1435), new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1442) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1917), new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1920) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1932), new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1933) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2363), new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2368) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2953), new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2956) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2975), new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2976) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2977), new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2979), new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 15, 20, 10, 826, DateTimeKind.Local).AddTicks(8197), new DateTime(2022, 3, 4, 15, 20, 10, 827, DateTimeKind.Local).AddTicks(3627) });
        }
    }
}
