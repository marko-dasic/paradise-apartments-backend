using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomsAndApartmentRelationshipNew3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                type: "datetime2",
                table: "Rooms",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 28, 23, 10, 34, 68, DateTimeKind.Local).AddTicks(8777));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                type: "datetime2",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                type: "datetime2",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                type: "bit",
                table: "Rooms",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Rooms");
        }

    }
}
