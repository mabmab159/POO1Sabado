using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public partial class Alumno
    {
        [Key] public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        [DisplayName("Fecha de Nacimiento")] public DateTime fechaNacimiento { get; set; }
        public string carrera { get; set; }

        public Alumno() { }
        public Alumno(int id, string nombre, string apellido, DateTime fechaNacimiento, string carrera)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.carrera = carrera;
        }
    }

    public enum carrera
    {
        Sistemas,
        Administracion,
        Contabilidad,
        Marketing
    }
}