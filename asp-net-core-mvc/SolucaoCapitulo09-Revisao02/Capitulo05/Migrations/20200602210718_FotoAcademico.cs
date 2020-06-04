using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capitulo05.Migrations
{
    public partial class FotoAcademico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Academicos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoMimeType",
                table: "Academicos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Academicos");

            migrationBuilder.DropColumn(
                name: "FotoMimeType",
                table: "Academicos");
        }
    }
}
