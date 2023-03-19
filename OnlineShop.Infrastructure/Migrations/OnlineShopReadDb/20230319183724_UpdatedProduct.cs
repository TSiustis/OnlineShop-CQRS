using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations.OnlineShopReadDb
{
    public partial class UpdatedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "read",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "read",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "read",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "read",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "read",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "read",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 3, 19, 18, 37, 24, 462, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 24, 13, 0, 45, 54, DateTimeKind.Unspecified).AddTicks(409), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "read",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "read",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "read",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "read",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "read",
                table: "Products");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "read",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 24, 13, 0, 45, 54, DateTimeKind.Unspecified).AddTicks(409), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 3, 19, 18, 37, 24, 462, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
