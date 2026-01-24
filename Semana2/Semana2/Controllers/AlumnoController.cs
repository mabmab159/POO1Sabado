using Semana2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana2.Controllers
{
    public class AlumnoController : Controller
    {
        static List<Alumno> listaAlumnos = new List<Alumno>()
        {
            new Alumno(1, "Juan", "Perez", new DateTime(1995, 5, 23), "Sistemas"),
            new Alumno(2, "Maria", "Gomez", new DateTime(1996, 8, 15), "Administracion"),
            new Alumno(3, "Carlos", "Lopez", new DateTime(1994, 12, 3), "Contabilidad"),
            new Alumno(4, "Ana", "Martinez", new DateTime(1997, 3, 30), "Marketing")
        };

        public ActionResult Index()
        {
            return View(listaAlumnos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            AlumnoExcepciones.validarAlumno(alumno);
            listaAlumnos.Add(alumno);
            ViewBag.Mensaje = "Alumno creado exitosamente.";
            return View();
        }

        public ActionResult Details(int id)
        {
            var alumno = listaAlumnos.FirstOrDefault(a => a.id == id);
            return View(alumno);
        }

        public ActionResult Edit(int id)
        {
            var alumno = listaAlumnos.FirstOrDefault(a => a.id == id);
            return View(alumno);
        }

        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            var alumnoExistente = listaAlumnos.FirstOrDefault(a => a.id == alumno.id);
            alumnoExistente.nombre = alumno.nombre;
            alumnoExistente.apellido = alumno.apellido;
            alumnoExistente.fechaNacimiento = alumno.fechaNacimiento;
            alumnoExistente.carrera = alumno.carrera;
            ViewBag.Mensaje = "Alumno editado exitosamente.";
            return View();
        }

        public ActionResult Delete(int id)
        {
            var alumno = listaAlumnos.FirstOrDefault(a => a.id == id);
            return View(alumno);
        }

        [HttpPost]
        public ActionResult Delete(Alumno alumno)
        {
            listaAlumnos.RemoveAll(a => a.id == alumno.id);
            return RedirectToAction("Index");
        }
    }
}