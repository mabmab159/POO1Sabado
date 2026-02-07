using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana4.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
    }
}