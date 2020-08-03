using Microsoft.EntityFrameworkCore.Migrations;

namespace Capitulo05Migrations.Migrations
{
    public partial class AtendimentoItemEFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtendimentoFotos",
                columns: table => new
                {
                    AtendimentoFotoID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AtendimentoID = table.Column<long>(nullable: true),
                    CaminhoFoto = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoFotos", x => x.AtendimentoFotoID);
                    table.ForeignKey(
                        name: "FK_AtendimentoFotos_Atendimentos_AtendimentoID",
                        column: x => x.AtendimentoID,
                        principalTable: "Atendimentos",
                        principalColumn: "AtendimentoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentoItens",
                columns: table => new
                {
                    AtendimentoItemID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AtendimentoID = table.Column<long>(nullable: true),
                    ServicoID = table.Column<long>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoItens", x => x.AtendimentoItemID);
                    table.ForeignKey(
                        name: "FK_AtendimentoItens_Atendimentos_AtendimentoID",
                        column: x => x.AtendimentoID,
                        principalTable: "Atendimentos",
                        principalColumn: "AtendimentoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtendimentoItens_Servicos_ServicoID",
                        column: x => x.ServicoID,
                        principalTable: "Servicos",
                        principalColumn: "ServicoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoFotos_AtendimentoID",
                table: "AtendimentoFotos",
                column: "AtendimentoID");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoItens_AtendimentoID",
                table: "AtendimentoItens",
                column: "AtendimentoID");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoItens_ServicoID",
                table: "AtendimentoItens",
                column: "ServicoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentoFotos");

            migrationBuilder.DropTable(
                name: "AtendimentoItens");
        }
    }
}
