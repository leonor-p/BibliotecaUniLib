using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_UniLib.Data.Migrations
{
    /// <inheritdoc />
    public partial class addPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.CreateTable(
           name: "Perfis",
           columns: table => new
           {
               Id = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"),
               Username = table.Column<string>(type: "nvarchar(50)", nullable: false),
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_Perfis", x => x.Id);
       });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Perfis");
        }
    }
}
