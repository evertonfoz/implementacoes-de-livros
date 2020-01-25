using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CasaDoCodigo.DataAccess.Migrations
{
    public partial class PecasCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<long>(
            //    name: "AtendimentoID",
            //    table: "AtendimentoItens",
            //    nullable: true,
            //    oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "Pecas",
                columns: table => new
                {
                    PecaID = table.Column<Guid>(nullable: false),
                    CaminhoImagem = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Sincronizado = table.Column<bool>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecas", x => x.PecaID);
                });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AtendimentoItens_Atendimentos_AtendimentoID",
            //    table: "AtendimentoItens",
            //    column: "AtendimentoID",
            //    principalTable: "Atendimentos",
            //    principalColumn: "AtendimentoID",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AtendimentoItens_Atendimentos_AtendimentoID",
            //    table: "AtendimentoItens");

            migrationBuilder.DropTable(
                name: "Pecas");

            migrationBuilder.AlterColumn<long>(
                name: "AtendimentoID",
                table: "AtendimentoItens",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
