using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_UniLib.Data.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByAdminID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Administradores_Administradores_CreatedByAdminID",
                        column: x => x.CreatedByAdminID,
                        principalTable: "Administradores",
                        principalColumn: "AdminID");
                });

            /*migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });*/

            /*migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });*/

            migrationBuilder.CreateTable(
                name: "Bibliotecas",
                columns: table => new
                {
                    BibliotecaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecas", x => x.BibliotecaID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Leitores",
                columns: table => new
                {
                    LeitorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferenciasNotificacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leitores", x => x.LeitorID);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    LivroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tema = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnoPublicacao = table.Column<int>(type: "int", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CopiasDisponiveis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.LivroID);
                });

            /*migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                });*/

            /*migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });*/

            /*migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });*/

            migrationBuilder.CreateTable(
                name: "Bibliotecarios",
                columns: table => new
                {
                    BibliotecarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BibliotecaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecarios", x => x.BibliotecarioID);
                    table.ForeignKey(
                        name: "FK_Bibliotecarios_Bibliotecas_BibliotecaID",
                        column: x => x.BibliotecaID,
                        principalTable: "Bibliotecas",
                        principalColumn: "BibliotecaID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    NotificacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeitorID = table.Column<int>(type: "int", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lida = table.Column<bool>(type: "bit", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.NotificacaoID);
                    table.ForeignKey(
                        name: "FK_Notificacoes_Leitores_LeitorID",
                        column: x => x.LeitorID,
                        principalTable: "Leitores",
                        principalColumn: "LeitorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    EmprestimoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeitorID = table.Column<int>(type: "int", nullable: false),
                    LivroID = table.Column<int>(type: "int", nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucaoPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.EmprestimoID);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Leitores_LeitorID",
                        column: x => x.LeitorID,
                        principalTable: "Leitores",
                        principalColumn: "LeitorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Livros_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livros",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoRequisicoes",
                columns: table => new
                {
                    HistoricoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeitorID = table.Column<int>(type: "int", nullable: false),
                    LivroID = table.Column<int>(type: "int", nullable: false),
                    DataAcao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Acao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoRequisicoes", x => x.HistoricoID);
                    table.ForeignKey(
                        name: "FK_HistoricoRequisicoes_Leitores_LeitorID",
                        column: x => x.LeitorID,
                        principalTable: "Leitores",
                        principalColumn: "LeitorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoRequisicoes_Livros_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livros",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsLivros",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroID = table.Column<int>(type: "int", nullable: false),
                    LeitorID = table.Column<int>(type: "int", nullable: false),
                    Avaliacao = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsLivros", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_ReviewsLivros_Leitores_LeitorID",
                        column: x => x.LeitorID,
                        principalTable: "Leitores",
                        principalColumn: "LeitorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewsLivros_Livros_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livros",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_CreatedByAdminID",
                table: "Administradores",
                column: "CreatedByAdminID");

            /*migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");*/

            /*migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");*/

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecarios_BibliotecaID",
                table: "Bibliotecarios",
                column: "BibliotecaID");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_LeitorID",
                table: "Emprestimos",
                column: "LeitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_LivroID",
                table: "Emprestimos",
                column: "LivroID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoRequisicoes_LeitorID",
                table: "HistoricoRequisicoes",
                column: "LeitorID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoRequisicoes_LivroID",
                table: "HistoricoRequisicoes",
                column: "LivroID");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_LeitorID",
                table: "Notificacoes",
                column: "LeitorID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsLivros_LeitorID",
                table: "ReviewsLivros",
                column: "LeitorID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsLivros_LivroID",
                table: "ReviewsLivros",
                column: "LivroID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bibliotecarios");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "HistoricoRequisicoes");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "ReviewsLivros");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bibliotecas");

            migrationBuilder.DropTable(
                name: "Leitores");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
