using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class TotalGeralConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco_Value",
                table: "Produto",
                newName: "Preco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produto",
                newName: "Preco");
        }
    }
}
