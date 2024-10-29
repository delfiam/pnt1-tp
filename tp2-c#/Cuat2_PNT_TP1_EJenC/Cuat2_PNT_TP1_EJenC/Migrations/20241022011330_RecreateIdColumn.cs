using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuat2_PNT_TP1_EJenC.Migrations
{
    /// <inheritdoc />
    public partial class RecreateIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Primero eliminamos la tabla si hay datos existentes
            migrationBuilder.DropTable(
                name: "Personas");

            // Vuelve a crear la tabla Personas con la columna de identidad
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    idPersona = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Define la columna como identidad
                    dni = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.idPersona);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Código para revertir la migración
            migrationBuilder.DropColumn(
                name: "idPersona",
                table: "Personas");

            migrationBuilder.AddColumn<long>(
                name: "idPersona",
                table: "Personas",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0); // Establece un valor predeterminado si es necesario
        }
    }
}
