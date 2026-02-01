using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public class Producto
    {
        [Key] public int id { get; set; }
        public string nombre { get; set; }
        [Required, MinLength(1)] public string categoria { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, string categoria, double precio, int stock)
        {
            this.id = id;
            this.nombre = nombre;
            this.categoria = categoria;
            this.precio = precio;
            this.stock = stock;
        }
    }

    public enum categoria
    {
        Electronica,
        Ropa,
        Hogar,
        Deportes
    }
}