using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addcancelledcolumninReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 220, DateTimeKind.Local).AddTicks(6880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 485, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 220, DateTimeKind.Local).AddTicks(1463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 484, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 219, DateTimeKind.Local).AddTicks(2409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 484, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 218, DateTimeKind.Local).AddTicks(3277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 483, DateTimeKind.Local).AddTicks(6805));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 218, DateTimeKind.Local).AddTicks(7633),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 484, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 217, DateTimeKind.Local).AddTicks(9326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 483, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 217, DateTimeKind.Local).AddTicks(5122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 482, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 217, DateTimeKind.Local).AddTicks(947),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 482, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 216, DateTimeKind.Local).AddTicks(5007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 482, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 215, DateTimeKind.Local).AddTicks(8495),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 481, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 215, DateTimeKind.Local).AddTicks(1107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 480, DateTimeKind.Local).AddTicks(8225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 214, DateTimeKind.Local).AddTicks(7054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 480, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 211, DateTimeKind.Local).AddTicks(9549),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 478, DateTimeKind.Local).AddTicks(5579));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "Reservations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 485, DateTimeKind.Local).AddTicks(3139),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 220, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 484, DateTimeKind.Local).AddTicks(8861),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 220, DateTimeKind.Local).AddTicks(1463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 484, DateTimeKind.Local).AddTicks(4921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 219, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 483, DateTimeKind.Local).AddTicks(6805),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 218, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 484, DateTimeKind.Local).AddTicks(354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 218, DateTimeKind.Local).AddTicks(7633));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 483, DateTimeKind.Local).AddTicks(3382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 217, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 482, DateTimeKind.Local).AddTicks(9814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 217, DateTimeKind.Local).AddTicks(5122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 482, DateTimeKind.Local).AddTicks(6289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 217, DateTimeKind.Local).AddTicks(947));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 482, DateTimeKind.Local).AddTicks(902),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 216, DateTimeKind.Local).AddTicks(5007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 481, DateTimeKind.Local).AddTicks(4771),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 215, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 480, DateTimeKind.Local).AddTicks(8225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 215, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 480, DateTimeKind.Local).AddTicks(4778),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 214, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 14, 23, 48, 478, DateTimeKind.Local).AddTicks(5579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 15, 21, 37, 49, 211, DateTimeKind.Local).AddTicks(9549));
        }
    }
}
