using GestorEstudiantil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorEstudiantil.DataAccess
{
    public class SemestreRepository : BaseRepository
    {
        public IQueryable<Semestre> Semestres => this.Context.Semestres;

        public bool Existe(Semestre semestre)
        {
            Semestre registro = this.Context.Semestres.FirstOrDefault(x => x.SemestreId == semestre.SemestreId);
            return registro != null;
        }

        public bool Guardar(Semestre semestre)
        {
            this.Context.Semestres.Add(semestre);
            return this.Context.SaveChanges() > 0;
        }
    }
}
