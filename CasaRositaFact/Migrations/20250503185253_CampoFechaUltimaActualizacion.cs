using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class CampoFechaUltimaActualizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaHasta",
                table: "PreciosArticulos",
                newName: "FechaUltimaActualizacion");

            migrationBuilder.RenameColumn(
                name: "FechaDesde",
                table: "PreciosArticulos",
                newName: "FechaIncio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaUltimaActualizacion",
                table: "PreciosArticulos",
                newName: "FechaHasta");

            migrationBuilder.RenameColumn(
                name: "FechaIncio",
                table: "PreciosArticulos",
                newName: "FechaDesde");
        }
    }
}
