using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Data.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    AuditLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.AuditLogId);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInCategories",
                columns: table => new
                {
                    ProductInCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInCategories", x => x.ProductInCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductInCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_ProductInCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_ProductInCategories_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedAt", "CreatorId", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1435), null, null, "Category 1", new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1442) },
                    { 2, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1917), null, null, "Category 2", new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1920) },
                    { 3, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1932), null, null, "Category 3", new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(1933) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedAt", "CreatorId", "DeletedAt", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2363), null, null, "Product 1", 100, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2368) },
                    { 2, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2953), null, null, "Product 2", 200, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2956) },
                    { 3, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2975), null, null, "Product 3", 600, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2976) },
                    { 4, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2977), null, null, "Product 4", 400, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2978) },
                    { 5, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2979), null, null, "Product 5", 900, new DateTime(2022, 3, 4, 15, 20, 10, 828, DateTimeKind.Local).AddTicks(2980) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "CreatorId", "DeletedAt", "Password", "RefreshToken", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2022, 3, 4, 15, 20, 10, 826, DateTimeKind.Local).AddTicks(8197), null, null, "$2a$05$pUOMJMojqb9AEY9ua8mMTOqa70Qyq4kFMiCWKPS8VaCh2N27OP6Ou", null, new DateTime(2022, 3, 4, 15, 20, 10, 827, DateTimeKind.Local).AddTicks(3627), "duclm21" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatorId",
                table: "Categories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCategories_CategoryId",
                table: "ProductInCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCategories_CreatorId",
                table: "ProductInCategories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCategories_ProductId",
                table: "ProductInCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatorId",
                table: "Products",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorId",
                table: "Users",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "ProductInCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
