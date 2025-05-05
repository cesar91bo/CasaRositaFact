using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class ModifiacionPrecioArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecioVenta",
                table: "PreciosArticulos",
                newName: "PrecioVentaSinIva");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioVentaConIva",
                table: "PreciosArticulos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioVentaConIva",
                table: "PreciosArticulos");

            migrationBuilder.RenameColumn(
                name: "PrecioVentaSinIva",
                table: "PreciosArticulos",
                newName: "PrecioVenta");
        }
    }
}
