using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Capitulo06Migrations.Migrations
{
    public partial class AtendimentosCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    AtendimentoID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteID = table.Column<long>(nullable: true),
                    DataHoraChegada = table.Column<DateTime>(nullable: false),
                    DataHoraEntrega = table.Column<DateTime>(nullable: true),
                    DataHoraPrometida = table.Column<DateTime>(nullable: false),
                    Veiculo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.AtendimentoID);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ClienteID",
                table: "Atendimentos",
                column: "ClienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");
        }
    }
}
