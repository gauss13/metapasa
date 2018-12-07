using Microsoft.EntityFrameworkCore.Migrations;

namespace MetaPasarela.Migrations
{
    public partial class Inicial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Grupos_GrupoId",
                table: "Reglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Paises_PaisId",
                table: "Reglas");

            migrationBuilder.AddForeignKey(
                name: "FK_Reglas_Grupos_GrupoId",
                table: "Reglas",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reglas_Paises_PaisId",
                table: "Reglas",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Grupos_GrupoId",
                table: "Reglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Paises_PaisId",
                table: "Reglas");

            migrationBuilder.AddForeignKey(
                name: "FK_Reglas_Grupos_GrupoId",
                table: "Reglas",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reglas_Paises_PaisId",
                table: "Reglas",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
