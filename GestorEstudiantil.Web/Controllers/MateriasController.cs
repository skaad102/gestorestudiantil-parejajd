using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestorEstudiantil.DataAccess;
using GestorEstudiantil.Models;

namespace GestorEstudiantil.Web.Controllers
{
    public class MateriasController : Controller
    {
        private MateriaRepository MateriasRepository;

        public MateriasController()
        {
            this.MateriasRepository = new MateriaRepository();
        }

        public IActionResult Index()
        {
            var model = this.MateriasRepository.Materias.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Materia materia)
        {
            if (ModelState.IsValid)
            {
                if (this.MateriasRepository.Existe(materia) == false)
                {
                    this.MateriasRepository.Guardar(materia);
                }
            }
            return RedirectToAction("Index");
        }
    }
}