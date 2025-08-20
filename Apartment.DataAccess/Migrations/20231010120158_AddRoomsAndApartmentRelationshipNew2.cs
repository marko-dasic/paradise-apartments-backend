using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomsAndApartmentRelationshipNew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WiFi",
                table: "Apartments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Garage",
                table: "Apartments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Apartments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WiFi",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Garage",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Apartments");
        }
    }
}
