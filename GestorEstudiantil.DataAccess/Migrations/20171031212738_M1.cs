using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GestorEstudiantil.DataAccess.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    EstudianteId = table.Column<string>(type: "TEXT", nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreMateria = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.MateriaId);
                });

            migrationBuilder.CreateTable(
                name: "Semestres",
                columns: table => new
                {
                    SemestreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreSemestre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestres", x => x.SemestreId);
                });

            migrationBuilder.CreateTable(
                name: "SemestreMaterias",
                columns: table => new
                {
                    SemestreMateriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MateriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    SemestreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemestreMaterias", x => x.SemestreMateriaId);
                    table.ForeignKey(
                        name: "FK_SemestreMaterias_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemestreMaterias_Semestres_SemestreId",
                        column: x => x.SemestreId,
                        principalTable: "Semestres",
                        principalColumn: "SemestreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteMatriculado",
                columns: table => new
                {
                    EstudianteMatriculadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EstudianteId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstudianteId1 = table.Column<string>(type: "TEXT", nullable: true),
                    FechaMatricula = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SemestreMateriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteMatriculado", x => x.EstudianteMatriculadoId);
                    table.ForeignKey(
                        name: "FK_EstudianteMatriculado_Estudiantes_EstudianteId1",
                        column: x => x.EstudianteId1,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstudianteMatriculado_SemestreMaterias_SemestreMateriaId",
                        column: x => x.SemestreMateriaId,
                        principalTable: "SemestreMaterias",
                        principalColumn: "SemestreMateriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    AsistenciaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Asistio = table.Column<bool>(type: "INTEGER", nullable: false),
                    EstudianteMatriculadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaAsistencia = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.AsistenciaId);
                    table.ForeignKey(
                        name: "FK_Asistencias_EstudianteMatriculado_EstudianteMatriculadoId",
                        column: x => x.EstudianteMatriculadoId,
                        principalTable: "EstudianteMatriculado",
                        principalColumn: "EstudianteMatriculadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_EstudianteMatriculadoId",
                table: "Asistencias",
                column: "EstudianteMatriculadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteMatriculado_EstudianteId1",
                table: "EstudianteMatriculado",
                column: "EstudianteId1");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteMatriculado_SemestreMateriaId",
                table: "EstudianteMatriculado",
                column: "SemestreMateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SemestreMaterias_MateriaId",
                table: "SemestreMaterias",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SemestreMaterias_SemestreId",
                table: "SemestreMaterias",
                column: "SemestreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "EstudianteMatriculado");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "SemestreMaterias");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Semestres");
        }
    }
}
