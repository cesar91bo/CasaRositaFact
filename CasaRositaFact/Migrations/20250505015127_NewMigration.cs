using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    IdBanco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.IdBanco);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    IdProvincia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.IdProvincia);
                });

            migrationBuilder.CreateTable(
                name: "RegimenesImpositivos",
                columns: table => new
                {
                    IdRegimenImpositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegimenesImpositivos", x => x.IdRegimenImpositivo);
                });

            migrationBuilder.CreateTable(
                name: "Rubros",
                columns: table => new
                {
                    IdRubro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.IdRubro);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumentos",
                columns: table => new
                {
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumentos", x => x.IdTipoDocumento);
                });

            migrationBuilder.CreateTable(
                name: "TiposIva",
                columns: table => new
                {
                    IdTipoIva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposIva", x => x.IdTipoIva);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                columns: table => new
                {
                    IdUnidadMedida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.IdUnidadMedida);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CUIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdBanco = table.Column<int>(type: "int", nullable: true),
                    CBU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_Proveedores_Bancos_IdBanco",
                        column: x => x.IdBanco,
                        principalTable: "Bancos",
                        principalColumn: "IdBanco",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    IdLocalidad = table.Column<int>(type: "int", nullable: false),
                    IdProvincia = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.IdLocalidad);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincias",
                        principalColumn: "IdProvincia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    CUIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdRegimenImpositivo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumentoIdTipoDocumento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_RegimenesImpositivos_IdRegimenImpositivo",
                        column: x => x.IdRegimenImpositivo,
                        principalTable: "RegimenesImpositivos",
                        principalColumn: "IdRegimenImpositivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_TiposDocumentos_IdTipoDocumento",
                        column: x => x.IdTipoDocumento,
                        principalTable: "TiposDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_TiposDocumentos_TipoDocumentoIdTipoDocumento",
                        column: x => x.TipoDocumentoIdTipoDocumento,
                        principalTable: "TiposDocumentos",
                        principalColumn: "IdTipoDocumento");
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
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
                    IdProveedor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_Articulos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Articulos_Proveedores_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Articulos_Rubros_IdRubro",
                        column: x => x.IdRubro,
                        principalTable: "Rubros",
                        principalColumn: "IdRubro",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Articulos_UnidadesMedida_IdUnidadMedida",
                        column: x => x.IdUnidadMedida,
                        principalTable: "UnidadesMedida",
                        principalColumn: "IdUnidadMedida",
                        onDelete: ReferentialAction.SetNull);
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
                    PorcentajeGanancia = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: false),
                    IdTipoIva = table.Column<int>(type: "int", nullable: true),
                    FechaIncio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUltimaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EsPrecioPublico = table.Column<bool>(type: "bit", nullable: false),
                    EsPrecioCosto = table.Column<bool>(type: "bit", nullable: false),
                    EsPrecioLista = table.Column<bool>(type: "bit", nullable: false),
                    EsPrecioDescuento = table.Column<bool>(type: "bit", nullable: false),
                    TipoIvaIdTipoIva = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "IdTipoIva",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PreciosArticulos_TiposIva_TipoIvaIdTipoIva",
                        column: x => x.TipoIvaIdTipoIva,
                        principalTable: "TiposIva",
                        principalColumn: "IdTipoIva");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdCategoria",
                table: "Articulos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdProveedor",
                table: "Articulos",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdRubro",
                table: "Articulos",
                column: "IdRubro");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_IdUnidadMedida",
                table: "Articulos",
                column: "IdUnidadMedida");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdRegimenImpositivo",
                table: "Clientes",
                column: "IdRegimenImpositivo");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdTipoDocumento",
                table: "Clientes",
                column: "IdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoDocumentoIdTipoDocumento",
                table: "Clientes",
                column: "TipoDocumentoIdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_IdProvincia",
                table: "Localidades",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_PreciosArticulos_IdArticulo",
                table: "PreciosArticulos",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_PreciosArticulos_IdTipoIva",
                table: "PreciosArticulos",
                column: "IdTipoIva");

            migrationBuilder.CreateIndex(
                name: "IX_PreciosArticulos_TipoIvaIdTipoIva",
                table: "PreciosArticulos",
                column: "TipoIvaIdTipoIva");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_IdBanco",
                table: "Proveedores",
                column: "IdBanco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "PreciosArticulos");

            migrationBuilder.DropTable(
                name: "RegimenesImpositivos");

            migrationBuilder.DropTable(
                name: "TiposDocumentos");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "TiposIva");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Rubros");

            migrationBuilder.DropTable(
                name: "UnidadesMedida");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
