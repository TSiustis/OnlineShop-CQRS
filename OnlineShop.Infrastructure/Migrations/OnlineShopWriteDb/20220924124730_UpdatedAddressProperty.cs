using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations.OnlineShopWriteDb
{
    public partial class UpdatedAddressProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                schema: "write",
                table: "Orders",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Street",
                schema: "write",
                table: "Orders",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "Country",
                schema: "write",
                table: "Orders",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                schema: "write",
                table: "Orders",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "Address",
                schema: "write",
                table: "Customers",
                newName: "Address_ZipCode");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "write",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 24, 12, 47, 29, 973, DateTimeKind.Unspecified).AddTicks(3779), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 4, 11, 53, 58, 538, DateTimeKind.Unspecified).AddTicks(7786), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "write",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "write",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "write",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "write",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "write",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "write",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                schema: "write",
                table: "Orders",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                schema: "write",
                table: "Orders",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                schema: "write",
                table: "Orders",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                schema: "write",
                table: "Orders",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                schema: "write",
                table: "Customers",
                newName: "Address");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "write",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 4, 11, 53, 58, 538, DateTimeKind.Unspecified).AddTicks(7786), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 24, 12, 47, 29, 973, DateTimeKind.Unspecified).AddTicks(3779), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
