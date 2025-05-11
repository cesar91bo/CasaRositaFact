using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionClaveTipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_TiposUsuarios_TipoUsuarioIdTipoUsuario",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_TipoUsuarioIdTipoUsuario",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "TipoUsuarioIdTipoUsuario",
                table: "Facturas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoUsuarioIdTipoUsuario",
                table: "Facturas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_TipoUsuarioIdTipoUsuario",
                table: "Facturas",
                column: "TipoUsuarioIdTipoUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_TiposUsuarios_TipoUsuarioIdTipoUsuario",
                table: "Facturas",
                column: "TipoUsuarioIdTipoUsuario",
                principalTable: "TiposUsuarios",
                principalColumn: "IdTipoUsuario");
        }
    }
}
