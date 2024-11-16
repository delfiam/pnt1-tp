using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turnera2.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Pacientes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MedicoId",
                table: "Medicos",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pacientes",
                newName: "PacienteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Medicos",
                newName: "MedicoId");
        }
    }
}
