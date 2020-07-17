using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfiguracoesDispositivos",
                columns: table => new
                {
                    ConfiguracaoDispositivoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracoesDispositivos", x => x.ConfiguracaoDispositivoId);
                });

            migrationBuilder.CreateTable(
                name: "Garcons",
                columns: table => new
                {
                    GarcomId = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Foto = table.Column<byte[]>(nullable: true),
                    DispositivoId = table.Column<long>(nullable: true),
                    EntityId = table.Column<long>(nullable: true),
                    OperacaoSincronismo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garcons", x => x.GarcomId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracoesDispositivos");

            migrationBuilder.DropTable(
                name: "Garcons");
        }
    }
}
