using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations.OnlineShopWriteDb
{
    public partial class UpdatedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "write",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "write",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "write",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "write",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "write",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "write",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 3, 19, 18, 37, 46, 915, DateTimeKind.Unspecified).AddTicks(7130), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 24, 13, 0, 54, 289, DateTimeKind.Unspecified).AddTicks(1047), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "write",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "write",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "write",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "write",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "write",
                table: "Products");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "write",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 24, 13, 0, 54, 289, DateTimeKind.Unspecified).AddTicks(1047), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 3, 19, 18, 37, 46, 915, DateTimeKind.Unspecified).AddTicks(7130), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
