using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Addrelationsspecpricetoapartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 96, DateTimeKind.Local).AddTicks(9289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 742, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 95, DateTimeKind.Local).AddTicks(2584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 740, DateTimeKind.Local).AddTicks(6938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 94, DateTimeKind.Local).AddTicks(7930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 737, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 94, DateTimeKind.Local).AddTicks(2959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 737, DateTimeKind.Local).AddTicks(3513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 93, DateTimeKind.Local).AddTicks(4060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 736, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 93, DateTimeKind.Local).AddTicks(7864),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 736, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(9802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 736, DateTimeKind.Local).AddTicks(650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(6214),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 735, DateTimeKind.Local).AddTicks(6265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(2406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 735, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 91, DateTimeKind.Local).AddTicks(6353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 734, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 90, DateTimeKind.Local).AddTicks(9547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 733, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 90, DateTimeKind.Local).AddTicks(2224),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 733, DateTimeKind.Local).AddTicks(2817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 89, DateTimeKind.Local).AddTicks(8352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 732, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 87, DateTimeKind.Local).AddTicks(8425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 730, DateTimeKind.Local).AddTicks(9659));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 742, DateTimeKind.Local).AddTicks(3780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 96, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 740, DateTimeKind.Local).AddTicks(6938),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 95, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 737, DateTimeKind.Local).AddTicks(8182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 94, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 737, DateTimeKind.Local).AddTicks(3513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 94, DateTimeKind.Local).AddTicks(2959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 736, DateTimeKind.Local).AddTicks(4244),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 93, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 736, DateTimeKind.Local).AddTicks(8756),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 93, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 736, DateTimeKind.Local).AddTicks(650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 735, DateTimeKind.Local).AddTicks(6265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 735, DateTimeKind.Local).AddTicks(1112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 734, DateTimeKind.Local).AddTicks(5534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 91, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 733, DateTimeKind.Local).AddTicks(9344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 90, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 733, DateTimeKind.Local).AddTicks(2817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 90, DateTimeKind.Local).AddTicks(2224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 732, DateTimeKind.Local).AddTicks(9009),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 89, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 7, 30, 730, DateTimeKind.Local).AddTicks(9659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 87, DateTimeKind.Local).AddTicks(8425));
        }
    }
}
