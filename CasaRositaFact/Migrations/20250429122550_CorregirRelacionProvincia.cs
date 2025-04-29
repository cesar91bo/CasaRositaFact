using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class CorregirRelacionProvincia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Provincias_ProvinciaIdProvincia",
                table: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_ProvinciaIdProvincia",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "ProvinciaIdProvincia",
                table: "Localidades");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_IdProvincia",
                table: "Localidades",
                column: "IdProvincia");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Provincias_IdProvincia",
                table: "Localidades",
                column: "IdProvincia",
                principalTable: "Provincias",
                principalColumn: "IdProvincia",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Provincias_IdProvincia",
                table: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_IdProvincia",
                table: "Localidades");

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaIdProvincia",
                table: "Localidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaIdProvincia",
                table: "Localidades",
                column: "ProvinciaIdProvincia");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Provincias_ProvinciaIdProvincia",
                table: "Localidades",
                column: "ProvinciaIdProvincia",
                principalTable: "Provincias",
                principalColumn: "IdProvincia",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
