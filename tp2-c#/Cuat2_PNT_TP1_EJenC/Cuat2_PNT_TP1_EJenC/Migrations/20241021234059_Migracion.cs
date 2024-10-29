using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuat2_PNT_TP1_EJenC.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    dni = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idPersona = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obraSocial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.dni);
                });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
