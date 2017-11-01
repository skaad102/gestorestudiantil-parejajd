using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEstudiantil.Models
{
    public class Estudiante
    {
        public string EstudianteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public IList<EstudianteMatriculado> Matriculas { get; set; }
    }
}
