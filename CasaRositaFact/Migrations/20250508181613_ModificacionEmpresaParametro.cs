using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaRositaFact.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionEmpresaParametro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
       name: "PK_Parametros",
       table: "Parametros");

            // Eliminás la columna IdParametro
            migrationBuilder.DropColumn(
                name: "IdParametro",
                table: "Parametros");

            // Agregás la nueva columna IdEmpresa (que actuará como clave foránea y primaria)
            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Parametros",
                type: "int",
                nullable: false,
                defaultValue: 0); // Ajustá esto según tu modelo de datos

            // Agregás la clave primaria
            migrationBuilder.AddPrimaryKey(
                name: "PK_Parametros",
                table: "Parametros",
                column: "IdEmpresa");

            // Agregás la columna nueva en Empresas
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaExpiracionCertificado",
                table: "Empresas",
                type: "datetime2",
                nullable: true);

            // Agregás la clave foránea
            migrationBuilder.AddForeignKey(
                name: "FK_Parametros_Empresas_IdEmpresa",
                table: "Parametros",
                column: "IdEmpresa",
                principalTable: "Empresas",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parametros_Empresas_IdEmpresa",
                table: "Parametros");

            migrationBuilder.DropColumn(
                name: "FechaExpiracionCertificado",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "IdEmpresa",
                table: "Parametros",
                newName: "IdParametro");

            migrationBuilder.AlterColumn<int>(
                name: "IdParametro",
                table: "Parametros",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
