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

        [HttpGet]
        public IActionResult Editar(int id)
        {
            //Consultamos el objeto
            var semestre = this.SemestreRepository.Semestres.FirstOrDefault(x => x.SemestreId == id);

            //Retornamos la vista
            return View(semestre);
        }

        [HttpPost]
        public IActionResult Editar(Semestre semestre)
        {
            bool guardado = this.SemestreRepository.Update(semestre.SemestreId, semestre);

            if (guardado)
            {
                return RedirectToAction("Index");
            }
            return View(semestre);
        }


        [HttpGet]
        public IActionResult Remover(int id)
        {
            //Consultamos el objeto
            var semestre = this.SemestreRepository.Semestres.FirstOrDefault(x => x.SemestreId == id);

            //Retornamos la vista
            return View(semestre);
        }

        [HttpPost]
        public IActionResult Remover(Semestre semestre)
        {
            bool guardado = this.SemestreRepository.Delete(semestre.SemestreId);

            if (guardado)
            {
                return RedirectToAction("Index");
            }
            return View(semestre);
        }

    }
}