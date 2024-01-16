using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoForeignKeyDaTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes",
                column: "ClassificacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes",
                column: "ClassificacaoId",
                unique: true);
        }
    }
}
