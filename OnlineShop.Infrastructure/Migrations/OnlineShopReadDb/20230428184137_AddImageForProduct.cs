﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations.OnlineShopReadDb
{
    public partial class AddImageForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                schema: "read",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "read",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                schema: "read",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "read",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 4, 28, 18, 41, 37, 789, DateTimeKind.Unspecified).AddTicks(8593), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 3, 19, 18, 37, 24, 462, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "read",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "read",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "read",
                table: "Products",
                column: "CategoryId",
                principalSchema: "read",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "read",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "read");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                schema: "read",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "read",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUri",
                schema: "read",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "read",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "OrderedAt",
                schema: "read",
                table: "Orders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 3, 19, 18, 37, 24, 462, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 4, 28, 18, 41, 37, 789, DateTimeKind.Unspecified).AddTicks(8593), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
