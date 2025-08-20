using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration23131 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecPrice_Apartments_ApartmentId",
                table: "SpecPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecPrice",
                table: "SpecPrice");

            migrationBuilder.RenameTable(
                name: "SpecPrice",
                newName: "SpecPrices");

            migrationBuilder.RenameIndex(
                name: "IX_SpecPrice_ApartmentId",
                table: "SpecPrices",
                newName: "IX_SpecPrices_ApartmentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 701, DateTimeKind.Local).AddTicks(5272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 96, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 699, DateTimeKind.Local).AddTicks(3707),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 94, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 698, DateTimeKind.Local).AddTicks(8642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 94, DateTimeKind.Local).AddTicks(2959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 697, DateTimeKind.Local).AddTicks(8816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 93, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 698, DateTimeKind.Local).AddTicks(2649),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 93, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 697, DateTimeKind.Local).AddTicks(4919),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 697, DateTimeKind.Local).AddTicks(1160),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 696, DateTimeKind.Local).AddTicks(7561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 696, DateTimeKind.Local).AddTicks(1563),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 91, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 695, DateTimeKind.Local).AddTicks(4928),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 90, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 694, DateTimeKind.Local).AddTicks(8304),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 90, DateTimeKind.Local).AddTicks(2224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 694, DateTimeKind.Local).AddTicks(4236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 89, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 692, DateTimeKind.Local).AddTicks(1953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 87, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 699, DateTimeKind.Local).AddTicks(8469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 95, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecPrices",
                table: "SpecPrices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecPrices_Apartments_ApartmentId",
                table: "SpecPrices",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecPrices_Apartments_ApartmentId",
                table: "SpecPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecPrices",
                table: "SpecPrices");

            migrationBuilder.RenameTable(
                name: "SpecPrices",
                newName: "SpecPrice");

            migrationBuilder.RenameIndex(
                name: "IX_SpecPrices_ApartmentId",
                table: "SpecPrice",
                newName: "IX_SpecPrice_ApartmentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 96, DateTimeKind.Local).AddTicks(9289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 701, DateTimeKind.Local).AddTicks(5272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 94, DateTimeKind.Local).AddTicks(7930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 699, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 94, DateTimeKind.Local).AddTicks(2959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 698, DateTimeKind.Local).AddTicks(8642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 93, DateTimeKind.Local).AddTicks(4060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 697, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 93, DateTimeKind.Local).AddTicks(7864),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 698, DateTimeKind.Local).AddTicks(2649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(9802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 697, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(6214),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 697, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 92, DateTimeKind.Local).AddTicks(2406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 696, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 91, DateTimeKind.Local).AddTicks(6353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 696, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 90, DateTimeKind.Local).AddTicks(9547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 695, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 90, DateTimeKind.Local).AddTicks(2224),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 694, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 89, DateTimeKind.Local).AddTicks(8352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 694, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 87, DateTimeKind.Local).AddTicks(8425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 692, DateTimeKind.Local).AddTicks(1953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SpecPrice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 24, 15, 9, 45, 95, DateTimeKind.Local).AddTicks(2584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 24, 15, 56, 53, 699, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecPrice",
                table: "SpecPrice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecPrice_Apartments_ApartmentId",
                table: "SpecPrice",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
