using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuat2_PNT_TP1_EJenC.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.RenameColumn(
                name: "obraSocial",
                table: "Persona",
                newName: "ObraSocial");

            migrationBuilder.RenameColumn(
                name: "especialidad",
                table: "Persona",
                newName: "Especialidad");

            migrationBuilder.AlterColumn<int>(
                name: "ObraSocial",
                table: "Persona",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "idPersona",
                table: "Persona",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Especialidad",
                table: "Persona",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "dni",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "idPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.RenameColumn(
                name: "ObraSocial",
                table: "Persona",
                newName: "obraSocial");

            migrationBuilder.RenameColumn(
                name: "Especialidad",
                table: "Persona",
                newName: "especialidad");

            migrationBuilder.AlterColumn<string>(
                name: "dni",
                table: "Persona",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "obraSocial",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "especialidad",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "idPersona",
                table: "Persona",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "dni");
        }
    }
}
