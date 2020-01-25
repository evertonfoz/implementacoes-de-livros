using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Capitulo06Migrations.Migrations
{
    public partial class AtendimentosItemCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtendimentoItens_Atendimentos_AtendimentoID",
                table: "AtendimentoItens");

            migrationBuilder.AlterColumn<long>(
                name: "AtendimentoID",
                table: "AtendimentoItens",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AtendimentoItens_Atendimentos_AtendimentoID",
                table: "AtendimentoItens",
                column: "AtendimentoID",
                principalTable: "Atendimentos",
                principalColumn: "AtendimentoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtendimentoItens_Atendimentos_AtendimentoID",
                table: "AtendimentoItens");

            migrationBuilder.AlterColumn<long>(
                name: "AtendimentoID",
                table: "AtendimentoItens",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_AtendimentoItens_Atendimentos_AtendimentoID",
                table: "AtendimentoItens",
                column: "AtendimentoID",
                principalTable: "Atendimentos",
                principalColumn: "AtendimentoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
