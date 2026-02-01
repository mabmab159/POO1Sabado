using Semana2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana2.Controllers
{
    public class CursoController : Controller
    {
        List<Curso> listaCursos = new List<Curso>()
        {
            new Curso(){ id=1, nombre="Matematicas", creditos=4 },
            new Curso(){ id=2, nombre="Fisica", creditos=3 },
            new Curso(){ id=6, nombre="Farmacia", creditos=3 },
            new Curso(){ id=3, nombre="Quimica", creditos=4 },
            new Curso(){ id=4, nombre="Historia", creditos=2 },
            new Curso(){ id=5, nombre="Lenguaje", creditos=3 },
        };

        public ActionResult Index()
        {
            var instancia = Singleton.GetInstancia();
            return View(listaCursos);
        }

        public ActionResult Filtro(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)){
                return View(new List<Curso>());
            }
            else
            {
                var cursosFiltrados = listaCursos.Where(e => e.nombre.StartsWith(nombre, StringComparison.CurrentCultureIgnoreCase));
                return View(cursosFiltrados);
            }
        }
    }
}