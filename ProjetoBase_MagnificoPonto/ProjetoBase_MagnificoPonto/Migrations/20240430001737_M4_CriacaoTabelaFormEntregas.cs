using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBase_MagnificoPonto.Migrations
{
    public partial class M4_CriacaoTabelaFormEntregas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormEntrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<int>(type: "int", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormEntrega", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormEntrega");
        }
    }
}
