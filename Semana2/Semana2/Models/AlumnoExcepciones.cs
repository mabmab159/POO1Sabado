using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public class AlumnoExcepciones: Exception
    {
        public AlumnoExcepciones()
        {
        }
        public AlumnoExcepciones(string message) : base(message)
        {
        }

        public AlumnoExcepciones(string message, Exception inner) : base(message, inner)
        {
        }

        public static void validarAlumno(Alumno alumno)
        {
            if(string.IsNullOrEmpty(alumno.nombre))
            {
                throw new AlumnoExcepciones("Error de programa - Nombres");
            }

            if(string.IsNullOrEmpty(alumno.apellido))
            {
                throw new AlumnoExcepciones("Error de programa - Apellidos");
            }
        }
    }
}