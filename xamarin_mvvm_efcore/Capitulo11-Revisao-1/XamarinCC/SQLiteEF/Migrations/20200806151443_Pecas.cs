using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaDoCodigo.DataAccess.Migrations
{
    public partial class Pecas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pecas",
                columns: table => new
                {
                    PecaID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    CaminhoImagem = table.Column<string>(nullable: true),
                    Sincronizado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecas", x => x.PecaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pecas");
        }
    }
}
