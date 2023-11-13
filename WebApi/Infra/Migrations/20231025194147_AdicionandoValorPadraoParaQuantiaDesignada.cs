using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoValorPadraoParaQuantiaDesignada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "QuantiaDesignada",
                table: "Quadros",
                type: "numeric(28,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(28,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "QuantiaDesignada",
                table: "Quadros",
                type: "numeric(28,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(28,2)",
                oldNullable: true,
                oldDefaultValue: 0m);
        }
    }
}
