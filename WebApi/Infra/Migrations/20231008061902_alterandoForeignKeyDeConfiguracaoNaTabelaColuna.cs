using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations;

/// <inheritdoc />
public partial class alterandoForeignKeyDeConfiguracaoNaTabelaColuna : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Colunas_Configuracoes_ConfiguracaoId",
            table: "Colunas");

        migrationBuilder.DropIndex(
            name: "IX_Colunas_ConfiguracaoId",
            table: "Colunas");

        migrationBuilder.DropColumn(
            name: "ConfiguracaoId",
            table: "Colunas");

        migrationBuilder.AddColumn<int>(
            name: "ColunaId",
            table: "Configuracoes",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Configuracoes_ColunaId",
            table: "Configuracoes",
            column: "ColunaId",
            unique: true,
            filter: "[ColunaId] IS NOT NULL");

        migrationBuilder.AddForeignKey(
            name: "FK_Configuracoes_Colunas_ColunaId",
            table: "Configuracoes",
            column: "ColunaId",
            principalTable: "Colunas",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Configuracoes_Colunas_ColunaId",
            table: "Configuracoes");

        migrationBuilder.DropIndex(
            name: "IX_Configuracoes_ColunaId",
            table: "Configuracoes");

        migrationBuilder.DropColumn(
            name: "ColunaId",
            table: "Configuracoes");

        migrationBuilder.AddColumn<int>(
            name: "ConfiguracaoId",
            table: "Colunas",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Colunas_ConfiguracaoId",
            table: "Colunas",
            column: "ConfiguracaoId",
            unique: true,
            filter: "[ConfiguracaoId] IS NOT NULL");

        migrationBuilder.AddForeignKey(
            name: "FK_Colunas_Configuracoes_ConfiguracaoId",
            table: "Colunas",
            column: "ConfiguracaoId",
            principalTable: "Configuracoes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
