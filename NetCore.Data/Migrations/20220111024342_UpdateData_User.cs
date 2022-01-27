using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Data.Migrations
{
    public partial class UpdateData_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(2253), new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(2260) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(2757), new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(2760) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(2772), new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(3136), new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(3935), new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(3957), new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(3958) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(3959), new DateTime(2022, 1, 11, 9, 43, 42, 388, DateTimeKind.Local).AddTicks(3960) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Creator", "DeletedAt", "Password", "RefreshToken", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2022, 1, 11, 9, 43, 42, 386, DateTimeKind.Local).AddTicks(7496), null, null, "$2a$05$pUOMJMojqb9AEY9ua8mMTOqa70Qyq4kFMiCWKPS8VaCh2N27OP6Ou", null, new DateTime(2022, 1, 11, 9, 43, 42, 387, DateTimeKind.Local).AddTicks(3271), "duclm21" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

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
    }
}
