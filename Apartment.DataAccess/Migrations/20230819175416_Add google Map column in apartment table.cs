using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddgoogleMapcolumninapartmenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeoLocationX",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "GeoLocationY",
                table: "Apartments",
                newName: "GoogleMap");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 284, DateTimeKind.Local).AddTicks(740),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 411, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 283, DateTimeKind.Local).AddTicks(6496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 411, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 283, DateTimeKind.Local).AddTicks(1979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 411, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 282, DateTimeKind.Local).AddTicks(3918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 410, DateTimeKind.Local).AddTicks(1604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 282, DateTimeKind.Local).AddTicks(7599),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 410, DateTimeKind.Local).AddTicks(5559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 282, DateTimeKind.Local).AddTicks(447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 409, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 281, DateTimeKind.Local).AddTicks(7019),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 409, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 281, DateTimeKind.Local).AddTicks(3270),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 408, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 280, DateTimeKind.Local).AddTicks(7804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 408, DateTimeKind.Local).AddTicks(3941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 280, DateTimeKind.Local).AddTicks(1898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 407, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 279, DateTimeKind.Local).AddTicks(5606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 407, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 279, DateTimeKind.Local).AddTicks(2091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 406, DateTimeKind.Local).AddTicks(6854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 277, DateTimeKind.Local).AddTicks(2394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 404, DateTimeKind.Local).AddTicks(6721));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoogleMap",
                table: "Apartments",
                newName: "GeoLocationY");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 411, DateTimeKind.Local).AddTicks(9337),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 284, DateTimeKind.Local).AddTicks(740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 411, DateTimeKind.Local).AddTicks(4927),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 283, DateTimeKind.Local).AddTicks(6496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 411, DateTimeKind.Local).AddTicks(106),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 283, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 410, DateTimeKind.Local).AddTicks(1604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 282, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 410, DateTimeKind.Local).AddTicks(5559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 282, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 409, DateTimeKind.Local).AddTicks(7942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 282, DateTimeKind.Local).AddTicks(447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 409, DateTimeKind.Local).AddTicks(4011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 281, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 408, DateTimeKind.Local).AddTicks(9592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 281, DateTimeKind.Local).AddTicks(3270));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 408, DateTimeKind.Local).AddTicks(3941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 280, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 407, DateTimeKind.Local).AddTicks(7483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 280, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 407, DateTimeKind.Local).AddTicks(575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 279, DateTimeKind.Local).AddTicks(5606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 406, DateTimeKind.Local).AddTicks(6854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 279, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 44, 11, 404, DateTimeKind.Local).AddTicks(6721),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 19, 54, 16, 277, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.AddColumn<string>(
                name: "GeoLocationX",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
