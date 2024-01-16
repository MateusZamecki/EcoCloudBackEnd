using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoDescricaoNaTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes");

            migrationBuilder.AlterColumn<int>(
                name: "ClassificacaoId",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Transacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes",
                column: "ClassificacaoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Transacoes");

            migrationBuilder.AlterColumn<int>(
                name: "ClassificacaoId",
                table: "Transacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ClassificacaoId",
                table: "Transacoes",
                column: "ClassificacaoId",
                unique: true,
                filter: "[ClassificacaoId] IS NOT NULL");
        }
    }
}
