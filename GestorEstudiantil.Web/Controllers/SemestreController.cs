using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestorEstudiantil.DataAccess;
using GestorEstudiantil.Models;

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

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Semestre semestre)
        {
            if (ModelState.IsValid)
            {
                if (this.SemestreRepository.Existe(semestre) == false)
                {
                    this.SemestreRepository.Guardar(semestre);
                }
            }
            return RedirectToAction("Index");
        }
    }
}