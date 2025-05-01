using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class AddPreciosTipoIva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Categoria_IdCategoria",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Proveedor_IdProveedor",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Rubro_IdRubro",
                table: "Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_UnidadMedida_IdUnidadMedida",
                table: "Articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadMedida",
                table: "UnidadMedida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rubro",
                table: "Rubro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo");

            migrationBuilder.RenameTable(
                name: "UnidadMedida",
                newName: "UnidadesMedida");

            migrationBuilder.RenameTable(
                name: "Rubro",
                newName: "Rubros");

            migrationBuilder.RenameTable(
                name: "Proveedor",
                newName: "Proveedores");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorias");

            migrationBuilder.RenameTable(
                name: "Articulo",
                newName: "Articulos");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_IdUnidadMedida",
                table: "Articulos",
                newName: "IX_Articulos_IdUnidadMedida");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_IdRubro",
                table: "Articulos",
                newName: "IX_Articulos_IdRubro");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_IdProveedor",
                table: "Articulos",
                newName: "IX_Articulos_IdProveedor");

            migrationBuilder.RenameIndex(
                name: "IX_Articulo_IdCategoria",
                table: "Articulos",
                newName: "IX_Articulos_IdCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesMedida",
                column: "IdUnidadMedida");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rubros",
                table: "Rubros",
                column: "IdRubro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores",
                column: "IdProveedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "IdCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "IdArticulo");

            migrationBuilder.CreateTable(
                name: "TiposIva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposIva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreciosArticulos",
                columns: table => new
                {
                    IdPrecioArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArticulo = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrecioCosto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrecioLista = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrecioDescuento = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IdTipoIva = table.Column<int>(type: "int", nullable: true),
                    FechaDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EsPrecioPublico = table.Column<bool>(type: "bit", nullable: false),
                    EsPrecioCosto = table.Column<bool>(type: "bit", nullable: false),
                    EsPrecioLista = table.Column<bool>(type: "bit", nullable: false),
                    EsPrecioDescuento = table.Column<bool>(type: "bit", nullable: false),
                    TipoIvaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreciosArticulos", x => x.IdPrecioArticulo);
                    table.ForeignKey(
                        name: "FK_PreciosArticulos_Articulos_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreciosArticulos_TiposIva_IdTipoIva",
                        column: x => x.IdTipoIva,
                        principalTable: "TiposIva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PreciosArticulos_TiposIva_TipoIvaId",
                        column: x => x.TipoIvaId,
                        principalTable: "TiposIva",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreciosArticulos_IdArticulo",
                table: "PreciosArticulos",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_PreciosArticulos_IdTipoIva",
                table: "PreciosArticulos",
                column: "IdTipoIva");

            migrationBuilder.CreateIndex(
                name: "IX_PreciosArticulos_TipoIvaId",
                table: "PreciosArticulos",
                column: "TipoIvaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Categorias_IdCategoria",
                table: "Articulos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Proveedores_IdProveedor",
                table: "Articulos",
                column: "IdProveedor",
                principalTable: "Proveedores",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Rubros_IdRubro",
                table: "Articulos",
                column: "IdRubro",
                principalTable: "Rubros",
                principalColumn: "IdRubro",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_UnidadesMedida_IdUnidadMedida",
                table: "Articulos",
                column: "IdUnidadMedida",
                principalTable: "UnidadesMedida",
                principalColumn: "IdUnidadMedida",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Categorias_IdCategoria",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Proveedores_IdProveedor",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Rubros_IdRubro",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_UnidadesMedida_IdUnidadMedida",
                table: "Articulos");

            migrationBuilder.DropTable(
                name: "PreciosArticulos");

            migrationBuilder.DropTable(
                name: "TiposIva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesMedida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rubros",
                table: "Rubros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.RenameTable(
                name: "UnidadesMedida",
                newName: "UnidadMedida");

            migrationBuilder.RenameTable(
                name: "Rubros",
                newName: "Rubro");

            migrationBuilder.RenameTable(
                name: "Proveedores",
                newName: "Proveedor");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categoria");

            migrationBuilder.RenameTable(
                name: "Articulos",
                newName: "Articulo");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_IdUnidadMedida",
                table: "Articulo",
                newName: "IX_Articulo_IdUnidadMedida");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_IdRubro",
                table: "Articulo",
                newName: "IX_Articulo_IdRubro");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_IdProveedor",
                table: "Articulo",
                newName: "IX_Articulo_IdProveedor");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_IdCategoria",
                table: "Articulo",
                newName: "IX_Articulo_IdCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadMedida",
                table: "UnidadMedida",
                column: "IdUnidadMedida");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rubro",
                table: "Rubro",
                column: "IdRubro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor",
                column: "IdProveedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "IdCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo",
                column: "IdArticulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Categoria_IdCategoria",
                table: "Articulo",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Proveedor_IdProveedor",
                table: "Articulo",
                column: "IdProveedor",
                principalTable: "Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Rubro_IdRubro",
                table: "Articulo",
                column: "IdRubro",
                principalTable: "Rubro",
                principalColumn: "IdRubro",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_UnidadMedida_IdUnidadMedida",
                table: "Articulo",
                column: "IdUnidadMedida",
                principalTable: "UnidadMedida",
                principalColumn: "IdUnidadMedida",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
