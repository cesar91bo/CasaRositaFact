using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class LimpiarFKDuplicadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Categoria_CategoriaIdCategoria",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Proveedor_ProveedorIdProveedor",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Rubro_RubroIdRubro",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_UnidadMedida_UnidadMedidaIdUnidadMedida",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_CategoriaIdCategoria",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_ProveedorIdProveedor",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_RubroIdRubro",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_UnidadMedidaIdUnidadMedida",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "ProveedorIdProveedor",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "RubroIdRubro",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "UnidadMedidaIdUnidadMedida",
                table: "Articulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Articulo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorIdProveedor",
                table: "Articulo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RubroIdRubro",
                table: "Articulo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnidadMedidaIdUnidadMedida",
                table: "Articulo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_CategoriaIdCategoria",
                table: "Articulo",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_ProveedorIdProveedor",
                table: "Articulo",
                column: "ProveedorIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_RubroIdRubro",
                table: "Articulo",
                column: "RubroIdRubro");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_UnidadMedidaIdUnidadMedida",
                table: "Articulo",
                column: "UnidadMedidaIdUnidadMedida");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Categoria_CategoriaIdCategoria",
                table: "Articulo",
                column: "CategoriaIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Proveedor_ProveedorIdProveedor",
                table: "Articulo",
                column: "ProveedorIdProveedor",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Rubro_RubroIdRubro",
                table: "Articulo",
                column: "RubroIdRubro",
                principalTable: "Rubro",
                principalColumn: "IdRubro");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_UnidadMedida_UnidadMedidaIdUnidadMedida",
                table: "Articulo",
                column: "UnidadMedidaIdUnidadMedida",
                principalTable: "UnidadMedida",
                principalColumn: "IdUnidadMedida");
        }
    }
}
