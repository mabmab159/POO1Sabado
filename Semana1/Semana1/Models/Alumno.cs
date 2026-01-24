using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana1.Models
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Codigo { get; set; }


        public Alumno()
        {
            Nombre = "Miguel";
            Apellido = "Berrio";
            Codigo = "A001";
        }

        public Alumno(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
            Codigo = "A002";
        }

        public Alumno(string nombre, string apellido, string codigo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Codigo = codigo;
        }

        public string nombreCompleto()
        {
            return Nombre + " " + Apellido;
        }

        public string nombreCompleto(string nombre)
        {
            return Nombre + " " + Apellido;
        }

        public string nombreCompleto(int cantidad, string apellido)
        {
            return Nombre + " " + Apellido;
        }

        public string nombreCompleto(string apellido, int cantidad)
        {
            return Nombre + " " + Apellido;
        }
    }
}