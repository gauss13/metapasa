using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetaPasarela.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupoPais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GrupoId = table.Column<int>(nullable: false),
                    PaisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoPais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pasarela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Url = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasarela", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redpago",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Codigo = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redpago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransaccionEstados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransaccionId = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(maxLength: 10, nullable: true),
                    RespuestaPasarela = table.Column<string>(maxLength: 150, nullable: true),
                    FechaReg = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaccionEstados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEntidad",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false),
                    EntidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEntidad", x => new { x.UsuarioId, x.EntidadId });
                });

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Codigo = table.Column<string>(maxLength: 3, nullable: true),
                    LocalizacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entidad_Localizacion_LocalizacionId",
                        column: x => x.LocalizacionId,
                        principalTable: "Localizacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    PasarelaId = table.Column<int>(nullable: false),
                    RedPagoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_Pasarela_PasarelaId",
                        column: x => x.PasarelaId,
                        principalTable: "Pasarela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grupos_Redpago_RedPagoId",
                        column: x => x.RedPagoId,
                        principalTable: "Redpago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Correo = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    RolId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaReg = table.Column<DateTime>(nullable: false),
                    UrlInvocacion = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Codigo = table.Column<string>(maxLength: 3, nullable: true),
                    GrupoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pais_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trasacciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntidadId = table.Column<int>(nullable: false),
                    TipoInvocacion = table.Column<int>(nullable: false),
                    Token = table.Column<string>(maxLength: 50, nullable: true),
                    FechaExpiracion = table.Column<DateTime>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 50, nullable: true),
                    Importe = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DivisaBase = table.Column<string>(maxLength: 3, nullable: true),
                    DivisaCobro = table.Column<string>(maxLength: 3, nullable: true),
                    Ratio = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Agente = table.Column<string>(maxLength: 50, nullable: true),
                    Idioma = table.Column<string>(maxLength: 20, nullable: true),
                    Cancelado = table.Column<bool>(nullable: false),
                    Finalizado = table.Column<bool>(nullable: false),
                    Confirmado_Pms = table.Column<bool>(nullable: false),
                    FechaReg = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    PasarelaId = table.Column<int>(nullable: false),
                    RedPagoId = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trasacciones_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trasacciones_Pasarela_PasarelaId",
                        column: x => x.PasarelaId,
                        principalTable: "Pasarela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trasacciones_Redpago_RedPagoId",
                        column: x => x.RedPagoId,
                        principalTable: "Redpago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trasacciones_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regla",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntidadId = table.Column<int>(nullable: false),
                    GrupoId = table.Column<int>(nullable: false),
                    PaisId = table.Column<int>(nullable: false),
                    RedPagoId = table.Column<int>(nullable: false),
                    PasarelaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regla_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regla_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regla_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regla_Pasarela_PasarelaId",
                        column: x => x.PasarelaId,
                        principalTable: "Pasarela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regla_Redpago_RedPagoId",
                        column: x => x.RedPagoId,
                        principalTable: "Redpago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regla_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_LocalizacionId",
                table: "Entidad",
                column: "LocalizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_PasarelaId",
                table: "Grupos",
                column: "PasarelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_RedPagoId",
                table: "Grupos",
                column: "RedPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_GrupoId",
                table: "Pais",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Regla_EntidadId",
                table: "Regla",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Regla_GrupoId",
                table: "Regla",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Regla_PaisId",
                table: "Regla",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Regla_PasarelaId",
                table: "Regla",
                column: "PasarelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Regla_RedPagoId",
                table: "Regla",
                column: "RedPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Regla_UsuarioId",
                table: "Regla",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Trasacciones_EntidadId",
                table: "Trasacciones",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Trasacciones_PasarelaId",
                table: "Trasacciones",
                column: "PasarelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Trasacciones_RedPagoId",
                table: "Trasacciones",
                column: "RedPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trasacciones_UsuarioId",
                table: "Trasacciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoPais");

            migrationBuilder.DropTable(
                name: "Regla");

            migrationBuilder.DropTable(
                name: "TransaccionEstados");

            migrationBuilder.DropTable(
                name: "Trasacciones");

            migrationBuilder.DropTable(
                name: "UsuarioEntidad");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Localizacion");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Pasarela");

            migrationBuilder.DropTable(
                name: "Redpago");
        }
    }
}
