using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capitulo05.Migrations
{
    public partial class Academico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academicos",
                columns: table => new
                {
                    AcademicoID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistroAcademico = table.Column<string>(maxLength: 10, nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academicos", x => x.AcademicoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Academicos");
        }
    }
}
