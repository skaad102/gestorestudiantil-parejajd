using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEstudiantil.Models
{
    public class Asistencia
    {
        public int AsistenciaId { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public bool Asistio { get; set; }

        public int EstudianteMatriculadoId { get; set; }
        public EstudianteMatriculado EstudianteMatriculado { get; set; }
    }
}
