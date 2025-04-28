using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "RegimenesImpositivos");

            migrationBuilder.DropTable(
                name: "TiposDocumentos");
        }
    }
}
