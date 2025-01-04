using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_UniLib.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          ///  migrationBuilder.DropColumn(
               /// name: "Document",
               /// table: "courses"); 

            migrationBuilder.AddColumn<bool>(
                name: "Addrec",
                table: "courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dest",
                table: "courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addrec",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "Dest",
                table: "courses");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
