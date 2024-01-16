using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriandoEntidadeClassificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classificacao",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "QuantiaDesignada",
                table: "Quadros");

            migrationBuilder.AddColumn<bool>(
                name: "EhRecorrente",
                table: "Transacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Classificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classificacoes_Transacoes_TransacaoId",
                        column: x => x.TransacaoId,
                        principalTable: "Transacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classificacoes_TransacaoId",
                table: "Classificacoes",
                column: "TransacaoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classificacoes");

            migrationBuilder.DropColumn(
                name: "EhRecorrente",
                table: "Transacoes");

            migrationBuilder.AddColumn<int>(
                name: "Classificacao",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "QuantiaDesignada",
                table: "Quadros",
                type: "numeric(28,2)",
                nullable: true,
                defaultValue: 0m);
        }
    }
}
