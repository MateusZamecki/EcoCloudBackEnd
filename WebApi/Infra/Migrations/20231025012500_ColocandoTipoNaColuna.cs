using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations;

/// <inheritdoc />
public partial class ColocandoTipoNaColuna : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Tipo",
            table: "Transacoes");

        migrationBuilder.AddColumn<int>(
            name: "Tipo",
            table: "Colunas",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Tipo",
            table: "Colunas");

        migrationBuilder.AddColumn<int>(
            name: "Tipo",
            table: "Transacoes",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }
}
