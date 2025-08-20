using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomsAndApartmentRelationshipNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Apartments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_RoomId",
                table: "Apartments",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Rooms_RoomId",
                table: "Apartments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Rooms_RoomId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_RoomId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Apartments");

            migrationBuilder.DropTable(
                name: "Rooms");
        }

    }
}
