using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingnumberofpersonsinReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 456, DateTimeKind.Local).AddTicks(8260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 421, DateTimeKind.Local).AddTicks(3943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 454, DateTimeKind.Local).AddTicks(8730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 419, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 454, DateTimeKind.Local).AddTicks(4056),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 419, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(8986),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.AddColumn<int>(
                name: "NumPerson",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(332),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(4239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(3961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 452, DateTimeKind.Local).AddTicks(6137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 417, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 452, DateTimeKind.Local).AddTicks(2373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 417, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 451, DateTimeKind.Local).AddTicks(8359),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 416, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 451, DateTimeKind.Local).AddTicks(2580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 416, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 450, DateTimeKind.Local).AddTicks(6001),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 415, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 449, DateTimeKind.Local).AddTicks(8560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 415, DateTimeKind.Local).AddTicks(755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 449, DateTimeKind.Local).AddTicks(4629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 414, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 447, DateTimeKind.Local).AddTicks(566),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 412, DateTimeKind.Local).AddTicks(4149));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumPerson",
                table: "Reservations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 421, DateTimeKind.Local).AddTicks(3943),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 456, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 419, DateTimeKind.Local).AddTicks(7962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 454, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 419, DateTimeKind.Local).AddTicks(3342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 454, DateTimeKind.Local).AddTicks(4056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(8737),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 418, DateTimeKind.Local).AddTicks(3961),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 453, DateTimeKind.Local).AddTicks(4239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 417, DateTimeKind.Local).AddTicks(6632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 452, DateTimeKind.Local).AddTicks(6137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 417, DateTimeKind.Local).AddTicks(3038),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 452, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 416, DateTimeKind.Local).AddTicks(9450),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 451, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 416, DateTimeKind.Local).AddTicks(4057),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 451, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 415, DateTimeKind.Local).AddTicks(7654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 450, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 415, DateTimeKind.Local).AddTicks(755),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 449, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 414, DateTimeKind.Local).AddTicks(7093),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 449, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 24, 20, 12, 0, 412, DateTimeKind.Local).AddTicks(4149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 24, 20, 18, 15, 447, DateTimeKind.Local).AddTicks(566));
        }
    }
}
