using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations;

/// <inheritdoc />
public partial class AlterandoGastoParaTransacao : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Gastos");

        migrationBuilder.CreateTable(
            name: "Transacoes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nome = table.Column<string>(type: "varchar(50)", nullable: true),
                Quantia = table.Column<decimal>(type: "numeric(28,2)", nullable: true),
                DataDeCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                Tipo = table.Column<int>(type: "int", nullable: false),
                ColunaId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transacoes", x => x.Id);
                table.ForeignKey(
                    name: "FK_Transacoes_Colunas_ColunaId",
                    column: x => x.ColunaId,
                    principalTable: "Colunas",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Transacoes_ColunaId",
            table: "Transacoes",
            column: "ColunaId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Transacoes");

        migrationBuilder.CreateTable(
            name: "Gastos",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                ColunaId = table.Column<int>(type: "int", nullable: false),
                DataDeCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                Nome = table.Column<string>(type: "varchar(50)", nullable: true),
                Quantia = table.Column<decimal>(type: "numeric(28,2)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Gastos", x => x.Id);
                table.ForeignKey(
                    name: "FK_Gastos_Colunas_ColunaId",
                    column: x => x.ColunaId,
                    principalTable: "Colunas",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Gastos_ColunaId",
            table: "Gastos",
            column: "ColunaId");
    }
}
