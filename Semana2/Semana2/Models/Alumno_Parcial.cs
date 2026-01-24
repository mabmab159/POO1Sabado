using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public partial class Alumno: IAlumno //A implementar todos los metodos del contrato | Interface
    {
        public int edad()
        {
            return DateTime.Now.Year - fechaNacimiento.Year;
        }

        public string nombreCompleto()
        {
            return nombre + " " + apellido;
        }
    }
}