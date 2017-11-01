using System;
using System.Collections.Generic;
using System.Text;

namespace GestorEstudiantil.DataAccess
{
    public class BaseRepository
    {
        protected GestorEstudiantilDBContext Context;

        public BaseRepository()
        {
            this.Context = new GestorEstudiantilDBContext();
        }
    }
}
