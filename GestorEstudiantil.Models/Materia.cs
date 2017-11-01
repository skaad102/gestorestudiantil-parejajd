using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEstudiantil.Models
{
    public class Materia
    {
        public int MateriaId { get; set; }
        public string NombreMateria { get; set; }
        public IList<SemestreMateria> Materias { get; set; }
    }
}
