using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_UniLib.Data.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
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
                name: "Bibliotecarios");

            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "HistoricoRequisicoes");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "ReviewsLivros");

            migrationBuilder.DropTable(
                name: "Bibliotecas");

            migrationBuilder.DropTable(
                name: "Leitores");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
