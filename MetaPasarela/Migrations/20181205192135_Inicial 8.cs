using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetaPasarela.Migrations
{
    public partial class Inicial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afiliaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntidadId = table.Column<int>(nullable: false),
                    PasarelaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    NumAfiliacion = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Referencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Afiliaciones_Entidades_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliaciones_Pasarelas_PasarelaId",
                        column: x => x.PasarelaId,
                        principalTable: "Pasarelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliaciones_EntidadId",
                table: "Afiliaciones",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliaciones_PasarelaId",
                table: "Afiliaciones",
                column: "PasarelaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afiliaciones");
        }
    }
}
