using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Data.Migrations
{
    public partial class UpdateData_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(7250), new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(7736), new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(7752), new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(7753) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8171), new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8174) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8840), new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8844) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8861), new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8862) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8863), new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedAt", "Creator", "DeletedAt", "Name", "Price", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8865), null, null, "Product 5", 900, new DateTime(2022, 1, 27, 13, 37, 43, 326, DateTimeKind.Local).AddTicks(8865) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 27, 13, 37, 43, 325, DateTimeKind.Local).AddTicks(2502), new DateTime(2022, 1, 27, 13, 37, 43, 325, DateTimeKind.Local).AddTicks(8499) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 1, 11, 9, 43, 42, 386, DateTimeKind.Local).AddTicks(7496), new DateTime(2022, 1, 11, 9, 43, 42, 387, DateTimeKind.Local).AddTicks(3271) });
        }
    }
}
