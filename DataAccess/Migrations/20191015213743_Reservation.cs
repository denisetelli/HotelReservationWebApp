using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactPersonId = table.Column<int>(nullable: true),
                    MainGuestId = table.Column<int>(nullable: false),
                    RoomCategoryId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Departure = table.Column<DateTime>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                  
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_MainGuestId",
                        column: x => x.MainGuestId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_Reservations_Categories_RoomCategoryId",
                        column: x => x.RoomCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ContactPersonId",
                table: "Reservations",
                column: "ContactPersonId",
                filter: "[ContactPersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MainGuestId",
                table: "Reservations",
                column: "MainGuestId",
                filter: "[MainGuestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomCategoryId",
                table: "Reservations",
                column: "RoomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
