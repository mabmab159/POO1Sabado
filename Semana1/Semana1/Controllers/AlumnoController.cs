using Semana1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana1.Controllers
{
    public class AlumnoController : Controller
    {

        static List<Alumno> alumnos = new List<Alumno> { 
            new Alumno("Miguel", "Berrio", "A001"), new Alumno("Juan", "Contreras", "A002"), new Alumno("Ana", "Gomez", "A003")
        };

        public ActionResult Index()
        {
            return View(alumnos);
        }

        public ActionResult Bienvenidos()
        {
            Alumno alumno = new Alumno();
            ViewBag.nombreCompleto = alumno.nombreCompleto();
            return View(alumno);
        }

        public ActionResult Details(string codigoAlumno)
        {
            Alumno alumno = alumnos.Find(p => codigoAlumno.StartsWith(p.Codigo));
            return View(alumno);
        }

        [HttpGet]
        public ActionResult CrearAlumno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearAlumno(Alumno alumno)
        {
            alumnos.Add(alumno);
            ViewBag.mensaje = "Alumno creado correctamente.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string codigoAlumno)
        {
            Alumno alumno = alumnos.Find(p => codigoAlumno.StartsWith(p.Codigo));
            return View(alumno);
        }

        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            Alumno alumnoAnterior = alumnos.Find(p => alumno.Codigo.StartsWith(p.Codigo));
            alumnoAnterior.Nombre = alumno.Nombre;
            alumnoAnterior.Apellido = alumno.Apellido;
            ViewBag.mensaje = "Alumno ha sido actualizado de manera correcta";
            return View();
        }

    }
}