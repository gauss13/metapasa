using Microsoft.EntityFrameworkCore.Migrations;

namespace MetaPasarela.Migrations
{
    public partial class Inicial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Pasarelas_PasarelaId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_RedPagos_RedPagoId",
                table: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_PasarelaId",
                table: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_RedPagoId",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "PasarelaId",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "RedPagoId",
                table: "Grupos");

            migrationBuilder.AddColumn<string>(
                name: "Afiliacion",
                table: "Transacciones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ordenante",
                table: "Transacciones",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RedPagoId",
                table: "Reglas",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Afiliacion",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Ordenante",
                table: "Transacciones");

            migrationBuilder.AlterColumn<int>(
                name: "RedPagoId",
                table: "Reglas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PasarelaId",
                table: "Grupos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedPagoId",
                table: "Grupos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_PasarelaId",
                table: "Grupos",
                column: "PasarelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_RedPagoId",
                table: "Grupos",
                column: "RedPagoId");

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
        }
    }
}
