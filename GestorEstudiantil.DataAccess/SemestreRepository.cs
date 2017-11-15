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

        public bool Update(int idSemestre, Semestre semestreNuevo)
        {
            //Consultamos el objeto anterior
            var anterior = this.Context.Semestres.FirstOrDefault(x => x.SemestreId == idSemestre);

            //Si los datos cambiaron
            if (anterior.NombreSemestre.Equals(semestreNuevo.NombreSemestre) == false)
            {
                //Se cambian los datos con la nueva información
                anterior.NombreSemestre = semestreNuevo.NombreSemestre;
                //Se guardan los cambios
                return this.Context.SaveChanges() > 0;
            }
            return true;
        }

        public bool Delete(int semestreId)
        {
            //Consultamos el objeto anterior
            var anterior = this.Context.Semestres.FirstOrDefault(x => x.SemestreId == semestreId);
            //Se elimina el objeto
            this.Context.Semestres.Remove(anterior);
            //Se guardan los cambios
            return this.Context.SaveChanges() > 0;
        }
    }
}
