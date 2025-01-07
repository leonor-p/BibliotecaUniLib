using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_UniLib.Data.Migrations
{
    /// <inheritdoc />
    public partial class isbn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "courses");
        }
    }
}
