using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana1.Models
{
    public class AlumnoEgresado : Alumno, IAlumnoEgresado, IAlumno2
    {
        //Herencia usas extends : | Interfaces usas implements :
        public DateTime FechaEgreso { get; set; }
        public string Institucion { get; set; }
    }
}