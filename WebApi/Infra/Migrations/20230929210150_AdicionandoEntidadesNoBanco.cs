using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations;

/// <inheritdoc />
public partial class AdicionandoEntidadesNoBanco : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Configuracoes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Data = table.Column<DateTime>(type: "date", nullable: false),
                IntervaloDeDias = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Configuracoes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "LogDosServicos",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                TipoDeServico = table.Column<int>(type: "int", nullable: false),
                Mensagem = table.Column<string>(type: "varchar(500)", nullable: false),
                DataDeExcecucao = table.Column<DateTime>(type: "datetime", nullable: false),
                TipoDeInformacao = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LogDosServicos", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Usuarios",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                Email = table.Column<string>(type: "varchar(200)", nullable: false),
                DataDeCriacao = table.Column<DateTime>(type: "datetime", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Usuarios", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Quadros",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                UsuarioId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Quadros", x => x.Id);
                table.ForeignKey(
                    name: "FK_Quadros_Usuarios_UsuarioId",
                    column: x => x.UsuarioId,
                    principalTable: "Usuarios",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Colunas",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                ConfiguracaoId = table.Column<int>(type: "int", nullable: true),
                QuadroId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Colunas", x => x.Id);
                table.ForeignKey(
                    name: "FK_Colunas_Configuracoes_ConfiguracaoId",
                    column: x => x.ConfiguracaoId,
                    principalTable: "Configuracoes",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Colunas_Quadros_QuadroId",
                    column: x => x.QuadroId,
                    principalTable: "Quadros",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Gastos",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                Quantia = table.Column<decimal>(type: "numeric(28,2)", nullable: false),
                DataDeCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                ColunaId = table.Column<int>(type: "int", nullable: false)
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
            name: "IX_Colunas_ConfiguracaoId",
            table: "Colunas",
            column: "ConfiguracaoId",
            unique: true,
            filter: "[ConfiguracaoId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_Colunas_QuadroId",
            table: "Colunas",
            column: "QuadroId");

        migrationBuilder.CreateIndex(
            name: "IX_Gastos_ColunaId",
            table: "Gastos",
            column: "ColunaId");

        migrationBuilder.CreateIndex(
            name: "IX_Quadros_UsuarioId",
            table: "Quadros",
            column: "UsuarioId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Gastos");

        migrationBuilder.DropTable(
            name: "LogDosServicos");

        migrationBuilder.DropTable(
            name: "Colunas");

        migrationBuilder.DropTable(
            name: "Configuracoes");

        migrationBuilder.DropTable(
            name: "Quadros");

        migrationBuilder.DropTable(
            name: "Usuarios");
    }
}
