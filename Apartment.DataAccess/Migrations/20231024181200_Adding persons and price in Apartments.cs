using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingpersonsandpriceinApartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 421, DateTimeKind.Local).AddTicks(3943),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 932, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 419, DateTimeKind.Local).AddTicks(7962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 930, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.AddColumn<double>(
                name: "PricePerPerson",
                table: "SpecPrices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 419, DateTimeKind.Local).AddTicks(3342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 930, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(8737),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 929, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 928, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(3961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 929, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 417, DateTimeKind.Local).AddTicks(6632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 928, DateTimeKind.Local).AddTicks(3557));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 417, DateTimeKind.Local).AddTicks(3038),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 927, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 416, DateTimeKind.Local).AddTicks(9450),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 927, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 416, DateTimeKind.Local).AddTicks(4057),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 926, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 415, DateTimeKind.Local).AddTicks(7654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 926, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 415, DateTimeKind.Local).AddTicks(755),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 925, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 414, DateTimeKind.Local).AddTicks(7093),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 925, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 412, DateTimeKind.Local).AddTicks(4149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 922, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.AddColumn<int>(
                name: "MaxPerson",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinPerson",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PricePerPerson",
                table: "Apartments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerPerson",
                table: "SpecPrices");

            migrationBuilder.DropColumn(
                name: "MaxPerson",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "MinPerson",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "PricePerPerson",
                table: "Apartments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 932, DateTimeKind.Local).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 421, DateTimeKind.Local).AddTicks(3943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 930, DateTimeKind.Local).AddTicks(8015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 419, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 930, DateTimeKind.Local).AddTicks(2819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 419, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 929, DateTimeKind.Local).AddTicks(7535),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 928, DateTimeKind.Local).AddTicks(8094),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 929, DateTimeKind.Local).AddTicks(2152),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(3961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 928, DateTimeKind.Local).AddTicks(3557),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 417, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 927, DateTimeKind.Local).AddTicks(9880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 417, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 927, DateTimeKind.Local).AddTicks(5740),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 416, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 926, DateTimeKind.Local).AddTicks(9687),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 416, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 926, DateTimeKind.Local).AddTicks(2603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 415, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 925, DateTimeKind.Local).AddTicks(4414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 415, DateTimeKind.Local).AddTicks(755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 925, DateTimeKind.Local).AddTicks(53),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 414, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 10, 14, 10, 30, 922, DateTimeKind.Local).AddTicks(3438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 412, DateTimeKind.Local).AddTicks(4149));
        }
    }
}
