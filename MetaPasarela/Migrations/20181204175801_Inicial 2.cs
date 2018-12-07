using Microsoft.EntityFrameworkCore.Migrations;

namespace MetaPasarela.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entidad_Localizacion_LocalizacionId",
                table: "Entidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Pasarela_PasarelaId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Redpago_RedPagoId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pais_Grupos_GrupoId",
                table: "Pais");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Entidad_EntidadId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Pais_PaisId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Pasarela_PasarelaId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Redpago_RedPagoId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Usuario_UsuarioId",
                table: "Regla");

            migrationBuilder.DropForeignKey(
                name: "FK_Trasacciones_Entidad_EntidadId",
                table: "Trasacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Trasacciones_Pasarela_PasarelaId",
                table: "Trasacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Trasacciones_Redpago_RedPagoId",
                table: "Trasacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Trasacciones_Usuario_UsuarioId",
                table: "Trasacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Roles_RolId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioEntidad",
                table: "UsuarioEntidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trasacciones",
                table: "Trasacciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Redpago",
                table: "Redpago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pasarela",
                table: "Pasarela");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pais",
                table: "Pais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Localizacion",
                table: "Localizacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoPais",
                table: "GrupoPais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entidad",
                table: "Entidad");

            migrationBuilder.RenameTable(
                name: "UsuarioEntidad",
                newName: "UsuarioEntidades");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Trasacciones",
                newName: "Transacciones");

            migrationBuilder.RenameTable(
                name: "Redpago",
                newName: "RedPagos");

            migrationBuilder.RenameTable(
                name: "Pasarela",
                newName: "Pasarelas");

            migrationBuilder.RenameTable(
                name: "Pais",
                newName: "Paises");

            migrationBuilder.RenameTable(
                name: "Localizacion",
                newName: "Localizaciones");

            migrationBuilder.RenameTable(
                name: "GrupoPais",
                newName: "GrupoPaises");

            migrationBuilder.RenameTable(
                name: "Entidad",
                newName: "Entidades");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_RolId",
                table: "Usuarios",
                newName: "IX_Usuarios_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Trasacciones_UsuarioId",
                table: "Transacciones",
                newName: "IX_Transacciones_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Trasacciones_RedPagoId",
                table: "Transacciones",
                newName: "IX_Transacciones_RedPagoId");

            migrationBuilder.RenameIndex(
                name: "IX_Trasacciones_PasarelaId",
                table: "Transacciones",
                newName: "IX_Transacciones_PasarelaId");

            migrationBuilder.RenameIndex(
                name: "IX_Trasacciones_EntidadId",
                table: "Transacciones",
                newName: "IX_Transacciones_EntidadId");

            migrationBuilder.RenameIndex(
                name: "IX_Pais_GrupoId",
                table: "Paises",
                newName: "IX_Paises_GrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_Entidad_LocalizacionId",
                table: "Entidades",
                newName: "IX_Entidades_LocalizacionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioEntidades",
                table: "UsuarioEntidades",
                columns: new[] { "UsuarioId", "EntidadId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacciones",
                table: "Transacciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedPagos",
                table: "RedPagos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pasarelas",
                table: "Pasarelas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paises",
                table: "Paises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Localizaciones",
                table: "Localizaciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoPaises",
                table: "GrupoPaises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entidades",
                table: "Entidades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entidades_Localizaciones_LocalizacionId",
                table: "Entidades",
                column: "LocalizacionId",
                principalTable: "Localizaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Pasarelas_PasarelaId",
                table: "Grupos",
                column: "PasarelaId",
                principalTable: "Pasarelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_RedPagos_RedPagoId",
                table: "Grupos",
                column: "RedPagoId",
                principalTable: "RedPagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_Grupos_GrupoId",
                table: "Paises",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Entidades_EntidadId",
                table: "Regla",
                column: "EntidadId",
                principalTable: "Entidades",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Entidades_EntidadId",
                table: "Transacciones",
                column: "EntidadId",
                principalTable: "Entidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Pasarelas_PasarelaId",
                table: "Transacciones",
                column: "PasarelaId",
                principalTable: "Pasarelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_RedPagos_RedPagoId",
                table: "Transacciones",
                column: "RedPagoId",
                principalTable: "RedPagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Usuarios_UsuarioId",
                table: "Transacciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entidades_Localizaciones_LocalizacionId",
                table: "Entidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Pasarelas_PasarelaId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_RedPagos_RedPagoId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Paises_Grupos_GrupoId",
                table: "Paises");

            migrationBuilder.DropForeignKey(
                name: "FK_Regla_Entidades_EntidadId",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Entidades_EntidadId",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Pasarelas_PasarelaId",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_RedPagos_RedPagoId",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Usuarios_UsuarioId",
                table: "Transacciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioEntidades",
                table: "UsuarioEntidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacciones",
                table: "Transacciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedPagos",
                table: "RedPagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pasarelas",
                table: "Pasarelas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paises",
                table: "Paises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Localizaciones",
                table: "Localizaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoPaises",
                table: "GrupoPaises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entidades",
                table: "Entidades");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "UsuarioEntidades",
                newName: "UsuarioEntidad");

            migrationBuilder.RenameTable(
                name: "Transacciones",
                newName: "Trasacciones");

            migrationBuilder.RenameTable(
                name: "RedPagos",
                newName: "Redpago");

            migrationBuilder.RenameTable(
                name: "Pasarelas",
                newName: "Pasarela");

            migrationBuilder.RenameTable(
                name: "Paises",
                newName: "Pais");

            migrationBuilder.RenameTable(
                name: "Localizaciones",
                newName: "Localizacion");

            migrationBuilder.RenameTable(
                name: "GrupoPaises",
                newName: "GrupoPais");

            migrationBuilder.RenameTable(
                name: "Entidades",
                newName: "Entidad");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuario",
                newName: "IX_Usuario_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_UsuarioId",
                table: "Trasacciones",
                newName: "IX_Trasacciones_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_RedPagoId",
                table: "Trasacciones",
                newName: "IX_Trasacciones_RedPagoId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_PasarelaId",
                table: "Trasacciones",
                newName: "IX_Trasacciones_PasarelaId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_EntidadId",
                table: "Trasacciones",
                newName: "IX_Trasacciones_EntidadId");

            migrationBuilder.RenameIndex(
                name: "IX_Paises_GrupoId",
                table: "Pais",
                newName: "IX_Pais_GrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_Entidades_LocalizacionId",
                table: "Entidad",
                newName: "IX_Entidad_LocalizacionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioEntidad",
                table: "UsuarioEntidad",
                columns: new[] { "UsuarioId", "EntidadId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trasacciones",
                table: "Trasacciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Redpago",
                table: "Redpago",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pasarela",
                table: "Pasarela",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pais",
                table: "Pais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Localizacion",
                table: "Localizacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoPais",
                table: "GrupoPais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entidad",
                table: "Entidad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entidad_Localizacion_LocalizacionId",
                table: "Entidad",
                column: "LocalizacionId",
                principalTable: "Localizacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Pasarela_PasarelaId",
                table: "Grupos",
                column: "PasarelaId",
                principalTable: "Pasarela",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Redpago_RedPagoId",
                table: "Grupos",
                column: "RedPagoId",
                principalTable: "Redpago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pais_Grupos_GrupoId",
                table: "Pais",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Entidad_EntidadId",
                table: "Regla",
                column: "EntidadId",
                principalTable: "Entidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Pais_PaisId",
                table: "Regla",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Pasarela_PasarelaId",
                table: "Regla",
                column: "PasarelaId",
                principalTable: "Pasarela",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Redpago_RedPagoId",
                table: "Regla",
                column: "RedPagoId",
                principalTable: "Redpago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regla_Usuario_UsuarioId",
                table: "Regla",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trasacciones_Entidad_EntidadId",
                table: "Trasacciones",
                column: "EntidadId",
                principalTable: "Entidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trasacciones_Pasarela_PasarelaId",
                table: "Trasacciones",
                column: "PasarelaId",
                principalTable: "Pasarela",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trasacciones_Redpago_RedPagoId",
                table: "Trasacciones",
                column: "RedPagoId",
                principalTable: "Redpago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trasacciones_Usuario_UsuarioId",
                table: "Trasacciones",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Roles_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
