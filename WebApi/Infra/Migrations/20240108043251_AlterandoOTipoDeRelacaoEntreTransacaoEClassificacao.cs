using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoOTipoDeRelacaoEntreTransacaoEClassificacao : Migration
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
                column: "ClassificacaoId")
                .Annotation("SqlServer:Include", new string[0]);
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
                column: "ClassificacaoId");
        }
    }
}
