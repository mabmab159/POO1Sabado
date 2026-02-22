using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana5.Models
{
    public class Proveedor
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}