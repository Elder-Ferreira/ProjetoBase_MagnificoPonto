using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBase_MagnificoPonto.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Amigurumis");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Amigurumis",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Descrição",
                table: "Amigurumis",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descrição",
                table: "Amigurumis");

            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Amigurumis",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Amigurumis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
