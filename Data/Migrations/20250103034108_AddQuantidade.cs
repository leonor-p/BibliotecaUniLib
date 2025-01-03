using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_UniLib.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adicionar a coluna Quantidade
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover a coluna Quantidade
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Courses");
        }
    }
}
