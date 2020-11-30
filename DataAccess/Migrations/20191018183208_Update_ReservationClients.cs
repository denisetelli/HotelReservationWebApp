using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Update_ReservationClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationClient_Clients_ClientId",
                table: "ReservationClient");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationClient_Reservations_ReservationId",
                table: "ReservationClient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationClient",
                table: "ReservationClient");

            migrationBuilder.RenameTable(
                name: "ReservationClient",
                newName: "ReservationClients");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationClient_ClientId",
                table: "ReservationClients",
                newName: "IX_ReservationClients_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationClients",
                table: "ReservationClients",
                columns: new[] { "ReservationId", "ClientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationClients_Clients_ClientId",
                table: "ReservationClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationClients_Reservations_ReservationId",
                table: "ReservationClients",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationClients_Clients_ClientId",
                table: "ReservationClients");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationClients_Reservations_ReservationId",
                table: "ReservationClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationClients",
                table: "ReservationClients");

            migrationBuilder.RenameTable(
                name: "ReservationClients",
                newName: "ReservationClient");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationClients_ClientId",
                table: "ReservationClient",
                newName: "IX_ReservationClient_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationClient",
                table: "ReservationClient",
                columns: new[] { "ReservationId", "ClientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationClient_Clients_ClientId",
                table: "ReservationClient",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationClient_Reservations_ReservationId",
                table: "ReservationClient",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
