using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations;

/// <inheritdoc />
public partial class AdicionandoDeleteCascadeNasConfiguracoes : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Colunas_Configuracoes_ConfiguracaoId",
            table: "Colunas");

        migrationBuilder.AddForeignKey(
            name: "FK_Colunas_Configuracoes_ConfiguracaoId",
            table: "Colunas",
            column: "ConfiguracaoId",
            principalTable: "Configuracoes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Colunas_Configuracoes_ConfiguracaoId",
            table: "Colunas");

        migrationBuilder.AddForeignKey(
            name: "FK_Colunas_Configuracoes_ConfiguracaoId",
            table: "Colunas",
            column: "ConfiguracaoId",
            principalTable: "Configuracoes",
            principalColumn: "Id");
    }
}
