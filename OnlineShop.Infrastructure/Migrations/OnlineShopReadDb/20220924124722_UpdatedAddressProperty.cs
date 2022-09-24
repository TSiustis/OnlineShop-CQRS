using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations.OnlineShopReadDb
{
    public partial class UpdatedAddressProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                schema: "read",
                table: "Orders",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Street",
                schema: "read",
                table: "Orders",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "Country",
                schema: "read",
                table: "Orders",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                schema: "read",
                table: "Orders",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "Address",
                schema: "read",
                table: "Customers",
                newName: "Address_ZipCode");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "read",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 24, 12, 47, 22, 429, DateTimeKind.Unspecified).AddTicks(8105), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 4, 11, 15, 57, 784, DateTimeKind.Unspecified).AddTicks(4464), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "read",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "read",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "read",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "read",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "read",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "read",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                schema: "read",
                table: "Orders",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                schema: "read",
                table: "Orders",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                schema: "read",
                table: "Orders",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                schema: "read",
                table: "Orders",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                schema: "read",
                table: "Customers",
                newName: "Address");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "read",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 4, 11, 15, 57, 784, DateTimeKind.Unspecified).AddTicks(4464), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 24, 12, 47, 22, 429, DateTimeKind.Unspecified).AddTicks(8105), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
