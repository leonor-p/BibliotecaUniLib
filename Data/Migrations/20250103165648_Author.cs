using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_UniLib.Data.Migrations
{
    /// <inheritdoc />
    public partial class Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true);

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "courses");

           
        }
    }
}
