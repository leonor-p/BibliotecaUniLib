using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddPerfil : Migration
{

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Criação da tabela Perfis
            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                });

            // Criação da tabela intermediária PerfilRoles
            migrationBuilder.CreateTable(
                name: "PerfilRoles",
                columns: table => new
                {
                    PerfilId = table.Column<int>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilRoles", x => new { x.PerfilId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_PerfilRoles_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Índices para acelerar consultas (opcional)
            migrationBuilder.CreateIndex(
                name: "IX_PerfilRoles_RoleId",
                table: "PerfilRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remoção da tabela intermediária
            migrationBuilder.DropTable(
                name: "PerfilRoles");

            // Remoção da tabela Perfis
            migrationBuilder.DropTable(
                name: "Perfis");
        }
    }



