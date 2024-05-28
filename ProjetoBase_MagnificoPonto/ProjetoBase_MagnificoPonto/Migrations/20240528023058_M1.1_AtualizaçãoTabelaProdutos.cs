using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBase_MagnificoPonto.Migrations
{
    public partial class M11_AtualizaçãoTabelaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cadastro de Produtos");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Cadastro de Produtos");

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "Cadastro de Produtos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Cadastro de Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Cadastro de Produtos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Cadastro de Produtos");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cadastro de Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Cadastro de Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
