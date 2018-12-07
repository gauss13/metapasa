using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetaPasarela.Migrations
{
    public partial class Inicial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Afiliaciones");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Afiliaciones");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Afiliaciones");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Afiliaciones");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaExpiracion",
                table: "Transacciones",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "Transacciones",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ID_TPV",
                table: "Transacciones",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Transacciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Transacciones",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Paises",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Afiliaciones",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Divisa",
                table: "Afiliaciones",
                maxLength: 3,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_TPV",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Afiliaciones");

            migrationBuilder.DropColumn(
                name: "Divisa",
                table: "Afiliaciones");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaExpiracion",
                table: "Transacciones",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "Transacciones",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Paises",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Afiliaciones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Afiliaciones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Afiliaciones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Afiliaciones",
                nullable: true);
        }
    }
}
