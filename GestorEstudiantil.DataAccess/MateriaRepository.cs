using GestorEstudiantil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorEstudiantil.DataAccess
{
    public class MateriaRepository : BaseRepository
    {
        public IQueryable<Materia> Materias => this.Context.Materias;

        public bool Existe(Materia materia)
        {
            Materia registro = this.Context.Materias.FirstOrDefault(x => x.MateriaId == materia.MateriaId);
            return registro != null;
        }

        public bool Guardar(Materia materia)
        {
            this.Context.Materias.Add(materia);
            return this.Context.SaveChanges() > 0;
        }
    }
}
