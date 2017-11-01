using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEstudiantil.Models
{
    public class EstudianteMatriculado
    {
        public int EstudianteMatriculadoId { get; set; }
        public DateTime FechaMatricula { get; set; }

        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }

        public int SemestreMateriaId { get; set; }
        public SemestreMateria SemestreMateria { get; set; }

        public IList<Asistencia> Asistencias { get; set; }
    }
}
