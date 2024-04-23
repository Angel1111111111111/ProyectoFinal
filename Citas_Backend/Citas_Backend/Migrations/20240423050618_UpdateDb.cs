using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Citas_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fecha",
                schema: "cita",
                table: "pacientes",
                newName: "nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombre",
                schema: "cita",
                table: "pacientes",
                newName: "fecha");
        }
    }
}
