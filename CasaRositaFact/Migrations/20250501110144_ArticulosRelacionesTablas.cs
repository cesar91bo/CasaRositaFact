using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class ArticulosRelacionesTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Rubro",
                columns: table => new
                {
                    IdRubro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubro", x => x.IdRubro);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    IdUnidadMedida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.IdUnidadMedida);
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: true),
                    IdRubro = table.Column<int>(type: "int", nullable: true),
                    LlevarStock = table.Column<bool>(type: "bit", nullable: false),
                    StockActual = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    FechaUltimoIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CantidadMinima = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    IdUnidadMedida = table.Column<int>(type: "int", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodigoProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: true),
                    CategoriaIdCategoria = table.Column<int>(type: "int", nullable: true),
                    ProveedorIdProveedor = table.Column<int>(type: "int", nullable: true),
                    RubroIdRubro = table.Column<int>(type: "int", nullable: true),
                    UnidadMedidaIdUnidadMedida = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_Articulo_Categoria_CategoriaIdCategoria",
                        column: x => x.CategoriaIdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK_Articulo_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Articulo_Proveedor_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Articulo_Proveedor_ProveedorIdProveedor",
                        column: x => x.ProveedorIdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor");
                    table.ForeignKey(
                        name: "FK_Articulo_Rubro_IdRubro",
                        column: x => x.IdRubro,
                        principalTable: "Rubro",
                        principalColumn: "IdRubro",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Articulo_Rubro_RubroIdRubro",
                        column: x => x.RubroIdRubro,
                        principalTable: "Rubro",
                        principalColumn: "IdRubro");
                    table.ForeignKey(
                        name: "FK_Articulo_UnidadMedida_IdUnidadMedida",
                        column: x => x.IdUnidadMedida,
                        principalTable: "UnidadMedida",
                        principalColumn: "IdUnidadMedida",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Articulo_UnidadMedida_UnidadMedidaIdUnidadMedida",
                        column: x => x.UnidadMedidaIdUnidadMedida,
                        principalTable: "UnidadMedida",
                        principalColumn: "IdUnidadMedida");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_CategoriaIdCategoria",
                table: "Articulo",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdCategoria",
                table: "Articulo",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdProveedor",
                table: "Articulo",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdRubro",
                table: "Articulo",
                column: "IdRubro");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdUnidadMedida",
                table: "Articulo",
                column: "IdUnidadMedida");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Rubro");

            migrationBuilder.DropTable(
                name: "UnidadMedida");
        }
    }
}
