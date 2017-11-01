using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestorEstudiantil.DataAccess;

namespace GestorEstudiantil.Web.Controllers
{
    public class SemestreController : Controller
    {
        private SemestreRepository SemestreRepository;

        public SemestreController()
        {
            this.SemestreRepository = new SemestreRepository();
        }

        public IActionResult Index()
        {
            var list = this.SemestreRepository.Semestres.ToList();
            return View(list);
        }
    }
}