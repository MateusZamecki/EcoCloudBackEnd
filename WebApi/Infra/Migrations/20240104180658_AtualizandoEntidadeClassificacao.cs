using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoEntidadeClassificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Classificacoes_TransacaoId",
                table: "Classificacoes");

            migrationBuilder.AlterColumn<int>(
                name: "TransacaoId",
                table: "Classificacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Classificacoes_TransacaoId",
                table: "Classificacoes",
                column: "TransacaoId",
                unique: true,
                filter: "[TransacaoId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Classificacoes_TransacaoId",
                table: "Classificacoes");

            migrationBuilder.AlterColumn<int>(
                name: "TransacaoId",
                table: "Classificacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classificacoes_TransacaoId",
                table: "Classificacoes",
                column: "TransacaoId",
                unique: true);
        }
    }
}
