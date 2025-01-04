using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddRoles : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Adiciona os papéis diretamente na tabela AspNetRoles
        migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            values: new object[,]
            {
                { Guid.NewGuid().ToString(), "Admin", "ADMIN", Guid.NewGuid().ToString() },
                { Guid.NewGuid().ToString(), "Bibliotecario", "BIBLIOTECARIO", Guid.NewGuid().ToString() },
                { Guid.NewGuid().ToString(), "Leitor", "LEITOR", Guid.NewGuid().ToString() }
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Remove os papéis inseridos
        migrationBuilder.DeleteData(
            table: "AspNetRoles",
            keyColumn: "Name",
            keyValues: new object[] { "Admin", "Bibliotecario", "Leitor" });
    }
}
