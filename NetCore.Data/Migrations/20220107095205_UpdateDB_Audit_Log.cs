using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Data.Migrations
{
    public partial class UpdateDB_Audit_Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    AuditLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.AuditLogId);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(1148), new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(7893) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(8522), new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(8527) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(8539), new DateTime(2022, 1, 7, 16, 52, 5, 95, DateTimeKind.Local).AddTicks(8540) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(6606), new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(6613) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7256), new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7279), new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7281), new DateTime(2022, 1, 7, 16, 52, 5, 96, DateTimeKind.Local).AddTicks(7282) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 24, 10, 13, 29, 773, DateTimeKind.Local).AddTicks(6574), new DateTime(2021, 12, 24, 10, 13, 29, 774, DateTimeKind.Local).AddTicks(2359) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 24, 10, 13, 29, 774, DateTimeKind.Local).AddTicks(3067), new DateTime(2021, 12, 24, 10, 13, 29, 774, DateTimeKind.Local).AddTicks(3072) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 24, 10, 13, 29, 774, DateTimeKind.Local).AddTicks(3121), new DateTime(2021, 12, 24, 10, 13, 29, 774, DateTimeKind.Local).AddTicks(3122) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 24, 10, 13, 29, 775, DateTimeKind.Local).AddTicks(1383), new DateTime(2021, 12, 24, 10, 13, 29, 775, DateTimeKind.Local).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 24, 10, 13, 29, 775, DateTimeKind.Local).AddTicks(2100), new DateTime(2021, 12, 24, 10, 13, 29, 775, DateTimeKind.Local).AddTicks(2104) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 24, 10, 13, 29, 775, DateTimeKind.Local).AddTicks(2122), new DateTime(2021, 12, 24, 10, 13, 29, 775, DateTimeKind.Local).AddTicks(2124) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 24, 10, 13, 29, 775, DateTimeKind.Local).AddTicks(2125), new DateTime(2021, 12, 24, 10, 13, 29, 775, DateTimeKind.Local).AddTicks(2126) });
        }
    }
}
