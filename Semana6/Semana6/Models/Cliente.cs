using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana6.Models
{
    public class Cliente
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string pais { get; set; }
        public string telefono { get; set; }
    }
}