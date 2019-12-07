using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Capitulo02.Migrations
{
    public partial class CursoDisciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Departamentos_DepartamentoID",
                table: "Curso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Curso",
                table: "Curso");

            migrationBuilder.RenameTable(
                name: "Curso",
                newName: "Cursos");

            migrationBuilder.RenameIndex(
                name: "IX_Curso_DepartamentoID",
                table: "Cursos",
                newName: "IX_Cursos_DepartamentoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "CursoID");

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    DisciplinaID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.DisciplinaID);
                });

            migrationBuilder.CreateTable(
                name: "CursoDisciplina",
                columns: table => new
                {
                    CursoID = table.Column<long>(type: "bigint", nullable: false),
                    DisciplinaID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDisciplina", x => new { x.CursoID, x.DisciplinaID });
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Cursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Cursos",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Disciplinas_DisciplinaID",
                        column: x => x.DisciplinaID,
                        principalTable: "Disciplinas",
                        principalColumn: "DisciplinaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_DisciplinaID",
                table: "CursoDisciplina",
                column: "DisciplinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Departamentos_DepartamentoID",
                table: "Cursos",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Departamentos_DepartamentoID",
                table: "Cursos");

            migrationBuilder.DropTable(
                name: "CursoDisciplina");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.RenameTable(
                name: "Cursos",
                newName: "Curso");

            migrationBuilder.RenameIndex(
                name: "IX_Cursos_DepartamentoID",
                table: "Curso",
                newName: "IX_Curso_DepartamentoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Curso",
                table: "Curso",
                column: "CursoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Departamentos_DepartamentoID",
                table: "Curso",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
