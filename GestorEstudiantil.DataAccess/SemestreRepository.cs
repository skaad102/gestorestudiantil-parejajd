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
    }
}
