using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingstreetandstreetNumberinApartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 335, DateTimeKind.Local).AddTicks(3496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 456, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 335, DateTimeKind.Local).AddTicks(15),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 454, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 333, DateTimeKind.Local).AddTicks(2684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 454, DateTimeKind.Local).AddTicks(4056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 332, DateTimeKind.Local).AddTicks(8088),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 331, DateTimeKind.Local).AddTicks(9895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 332, DateTimeKind.Local).AddTicks(3542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(4239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 331, DateTimeKind.Local).AddTicks(6047),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 452, DateTimeKind.Local).AddTicks(6137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 331, DateTimeKind.Local).AddTicks(2537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 452, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 330, DateTimeKind.Local).AddTicks(9085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 451, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 330, DateTimeKind.Local).AddTicks(3693),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 451, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 329, DateTimeKind.Local).AddTicks(7122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 450, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 329, DateTimeKind.Local).AddTicks(224),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 449, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 328, DateTimeKind.Local).AddTicks(6557),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 449, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 326, DateTimeKind.Local).AddTicks(2021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 447, DateTimeKind.Local).AddTicks(566));

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Street",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Apartments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 456, DateTimeKind.Local).AddTicks(8260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 335, DateTimeKind.Local).AddTicks(3496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 454, DateTimeKind.Local).AddTicks(8730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 335, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 454, DateTimeKind.Local).AddTicks(4056),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 333, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(8986),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 332, DateTimeKind.Local).AddTicks(8088));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(332),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 331, DateTimeKind.Local).AddTicks(9895));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(4239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 332, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 452, DateTimeKind.Local).AddTicks(6137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 331, DateTimeKind.Local).AddTicks(6047));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 452, DateTimeKind.Local).AddTicks(2373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 331, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 451, DateTimeKind.Local).AddTicks(8359),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 330, DateTimeKind.Local).AddTicks(9085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 451, DateTimeKind.Local).AddTicks(2580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 330, DateTimeKind.Local).AddTicks(3693));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 450, DateTimeKind.Local).AddTicks(6001),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 329, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 449, DateTimeKind.Local).AddTicks(8560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 329, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 449, DateTimeKind.Local).AddTicks(4629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 328, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 447, DateTimeKind.Local).AddTicks(566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 4, 12, 14, 39, 326, DateTimeKind.Local).AddTicks(2021));
        }
    }
}
