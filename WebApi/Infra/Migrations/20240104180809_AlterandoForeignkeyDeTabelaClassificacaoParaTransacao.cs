using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoForeignkeyDeTabelaClassificacaoParaTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classificacoes_Transacoes_TransacaoId",
                table: "Classificacoes");

            migrationBuilder.DropIndex(
                name: "IX_Classificacoes_TransacaoId",
                table: "Classificacoes");

            migrationBuilder.DropColumn(
                name: "TransacaoId",
                table: "Classificacoes");

            migrationBuilder.AddColumn<int>(
                name: "ClassificacaoId",
                table: "Transacoes",
                type: "int",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes",
                column: "ClassificacaoId",
                unique: false,
                filter: "[ClassificacaoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Classificacoes_ClassificacaoId",
                table: "Transacoes",
                column: "ClassificacaoId",
                principalTable: "Classificacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Classificacoes_ClassificacaoId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "ClassificacaoId",
                table: "Transacoes");

            migrationBuilder.AddColumn<int>(
                name: "TransacaoId",
                table: "Classificacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classificacoes_TransacaoId",
                table: "Classificacoes",
                column: "TransacaoId",
                unique: true,
                filter: "[TransacaoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Classificacoes_Transacoes_TransacaoId",
                table: "Classificacoes",
                column: "TransacaoId",
                principalTable: "Transacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
