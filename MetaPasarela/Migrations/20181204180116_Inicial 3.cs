using Microsoft.EntityFrameworkCore.Migrations;

namespace MetaPasarela.Migrations
{
    public partial class Inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Entidades_EntidadId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Grupos_GrupoId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Paises_PaisId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Pasarelas_PasarelaId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_RedPagos_RedPagoId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Usuarios_UsuarioId",
                table: "Regla");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regla",
                table: "Regla");

            migrationBuilder.RenameTable(
                name: "Regla",
                newName: "Reglas");

            migrationBuilder.RenameIndex(
                name: "IX_Regla_UsuarioId",
                table: "Reglas",
                newName: "IX_Reglas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Regla_RedPagoId",
                table: "Reglas",
                newName: "IX_Reglas_RedPagoId");

            migrationBuilder.RenameIndex(
                name: "IX_Regla_PasarelaId",
                table: "Reglas",
                newName: "IX_Reglas_PasarelaId");

            migrationBuilder.RenameIndex(
                name: "IX_Regla_PaisId",
                table: "Reglas",
                newName: "IX_Reglas_PaisId");

            migrationBuilder.RenameIndex(
                name: "IX_Regla_GrupoId",
                table: "Reglas",
                newName: "IX_Reglas_GrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_Regla_EntidadId",
                table: "Reglas",
                newName: "IX_Reglas_EntidadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reglas",
                table: "Reglas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reglas_Entidades_EntidadId",
                table: "Reglas",
                column: "EntidadId",
                principalTable: "Entidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reglas_Pasarelas_PasarelaId",
                table: "Reglas",
                column: "PasarelaId",
                principalTable: "Pasarelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reglas_RedPagos_RedPagoId",
                table: "Reglas",
                column: "RedPagoId",
                principalTable: "RedPagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reglas_Usuarios_UsuarioId",
                table: "Reglas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Entidades_EntidadId",
                table: "Reglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Grupos_GrupoId",
                table: "Reglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Paises_PaisId",
                table: "Reglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Pasarelas_PasarelaId",
                table: "Reglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_RedPagos_RedPagoId",
                table: "Reglas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglas_Usuarios_UsuarioId",
                table: "Reglas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reglas",
                table: "Reglas");

            migrationBuilder.RenameTable(
                name: "Reglas",
                newName: "Regla");

            migrationBuilder.RenameIndex(
                name: "IX_Reglas_UsuarioId",
                table: "Regla",
                newName: "IX_Regla_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Reglas_RedPagoId",
                table: "Regla",
                newName: "IX_Regla_RedPagoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reglas_PasarelaId",
                table: "Regla",
                newName: "IX_Regla_PasarelaId");

            migrationBuilder.RenameIndex(
                name: "IX_Reglas_PaisId",
                table: "Regla",
                newName: "IX_Regla_PaisId");

            migrationBuilder.RenameIndex(
                name: "IX_Reglas_GrupoId",
                table: "Regla",
                newName: "IX_Regla_GrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reglas_EntidadId",
                table: "Regla",
                newName: "IX_Regla_EntidadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regla",
                table: "Regla",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Entidades_EntidadId",
                table: "Regla",
                column: "EntidadId",
                principalTable: "Entidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Grupos_GrupoId",
                table: "Regla",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Paises_PaisId",
                table: "Regla",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Pasarelas_PasarelaId",
                table: "Regla",
                column: "PasarelaId",
                principalTable: "Pasarelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_RedPagos_RedPagoId",
                table: "Regla",
                column: "RedPagoId",
                principalTable: "RedPagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Usuarios_UsuarioId",
                table: "Regla",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
