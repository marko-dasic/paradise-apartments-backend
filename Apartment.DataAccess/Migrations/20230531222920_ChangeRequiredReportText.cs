using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRequiredReportText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 560, DateTimeKind.Local).AddTicks(4506),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 73, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Specifications",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 559, DateTimeKind.Local).AddTicks(9910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 73, DateTimeKind.Local).AddTicks(4238));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 559, DateTimeKind.Local).AddTicks(5642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 72, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 558, DateTimeKind.Local).AddTicks(6959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 71, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ReportLines",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 559, DateTimeKind.Local).AddTicks(802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 72, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Rates",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 558, DateTimeKind.Local).AddTicks(3048),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 71, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Prices",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 557, DateTimeKind.Local).AddTicks(9264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 70, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 557, DateTimeKind.Local).AddTicks(5690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 70, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 556, DateTimeKind.Local).AddTicks(9408),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 69, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 556, DateTimeKind.Local).AddTicks(2242),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 68, DateTimeKind.Local).AddTicks(8777));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 555, DateTimeKind.Local).AddTicks(5143),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 68, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ApartmentSpecifications",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 555, DateTimeKind.Local).AddTicks(44),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 67, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Apartments",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 552, DateTimeKind.Local).AddTicks(9202),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 64, DateTimeKind.Local).AddTicks(5852));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 73, DateTimeKind.Local).AddTicks(9821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 560, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Specifications",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Specifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 73, DateTimeKind.Local).AddTicks(4238),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 559, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 72, DateTimeKind.Local).AddTicks(8039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 559, DateTimeKind.Local).AddTicks(5642));

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 71, DateTimeKind.Local).AddTicks(7880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 558, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ReportLines",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ReportLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 72, DateTimeKind.Local).AddTicks(2559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 559, DateTimeKind.Local).AddTicks(802));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Rates",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Rates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 71, DateTimeKind.Local).AddTicks(2996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 558, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Prices",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 70, DateTimeKind.Local).AddTicks(8797),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 557, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 70, DateTimeKind.Local).AddTicks(4930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 557, DateTimeKind.Local).AddTicks(5690));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 69, DateTimeKind.Local).AddTicks(8574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 556, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 68, DateTimeKind.Local).AddTicks(8777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 556, DateTimeKind.Local).AddTicks(2242));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 68, DateTimeKind.Local).AddTicks(935),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 555, DateTimeKind.Local).AddTicks(5143));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ApartmentSpecifications",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApartmentSpecifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 67, DateTimeKind.Local).AddTicks(6750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 555, DateTimeKind.Local).AddTicks(44));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Apartments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 64, DateTimeKind.Local).AddTicks(5852),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 1, 0, 29, 19, 552, DateTimeKind.Local).AddTicks(9202));
        }
    }
}
