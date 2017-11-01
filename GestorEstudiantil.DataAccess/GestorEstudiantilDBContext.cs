using GestorEstudiantil.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEstudiantil.DataAccess
{
    public class GestorEstudiantilDBContext : DbContext
    {
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<SemestreMateria> SemestreMaterias { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<EstudianteMatriculado> EstudianteMatriculado { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        public GestorEstudiantilDBContext() : base()
        {

        }

        public GestorEstudiantilDBContext(DbContextOptions<GestorEstudiantilDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gestorestudiantil.db");
        }
    }
}
