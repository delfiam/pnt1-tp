using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuat2_PNT_TP1_EJenC.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeTuMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Renombrar la columna existente
            migrationBuilder.RenameColumn(
                name: "NombreColumna",
                table: "NombreTabla",
                newName: "NombreColumna_Temp");

            // Crear la columna nueva con la propiedad IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "NombreColumna",
                table: "NombreTabla",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Copiar datos de la columna temporal a la nueva columna
            migrationBuilder.Sql("UPDATE NombreTabla SET NombreColumna = NombreColumna_Temp");

            // Eliminar la columna temporal
            migrationBuilder.DropColumn(
                name: "NombreColumna_Temp",
                table: "NombreTabla");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Invertir los cambios en caso de deshacer la migración
            migrationBuilder.AddColumn<int>(
                name: "NombreColumna_Temp",
                table: "NombreTabla",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE NombreTabla SET NombreColumna_Temp = NombreColumna");

            migrationBuilder.DropColumn(
                name: "NombreColumna",
                table: "NombreTabla");

            migrationBuilder.RenameColumn(
                name: "NombreColumna_Temp",
                table: "NombreTabla",
                newName: "NombreColumna");
        }
    }
    }
