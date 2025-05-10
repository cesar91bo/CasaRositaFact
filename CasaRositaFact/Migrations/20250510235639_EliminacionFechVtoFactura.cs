using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class EliminacionFechVtoFactura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaVtoFactura",
                table: "Parametros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVtoFactura",
                table: "Parametros",
                type: "datetime2",
                nullable: true);
        }
    }
}
