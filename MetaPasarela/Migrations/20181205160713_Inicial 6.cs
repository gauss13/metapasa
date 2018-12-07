using Microsoft.EntityFrameworkCore.Migrations;

namespace MetaPasarela.Migrations
{
    public partial class Inicial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Grupos_GrupoId",
                table: "Reglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Paises_PaisId",
                table: "Reglas");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "Reglas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GrupoId",
                table: "Reglas",
                nullable: true,
                oldClrType: typeof(int));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Grupos_GrupoId",
                table: "Reglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Paises_PaisId",
                table: "Reglas");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "Reglas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GrupoId",
                table: "Reglas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
