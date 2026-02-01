using Semana2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana2.Controllers
{
    public class ProductoController : Controller
    {
        static List<Producto> listaProductos = new List<Producto>()
        {
            new Producto(1, "Laptop", "Electronica", 1200.50, 10),
            new Producto(2, "Camisa", "Ropa", 35.99, 50),
            new Producto(3, "Sofá", "Hogar", 499.99, 5),
            new Producto(4, "Bicicleta", "Deportes", 299.99, 15)
        };
        public ActionResult Index()
        {
            return View(listaProductos);
        }

        public ActionResult Details(int id)
        {
            Producto producto = listaProductos.FirstOrDefault(p => p.id == id);
            return View(producto);
        }
    
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            listaProductos.Add(producto);
            ViewBag.Mensaje = "Producto creado exitosamente.";
            return View();
        }

        public ActionResult Edit(int id)
        {
            Producto producto = listaProductos.FirstOrDefault(p => p.id == id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            Producto prodExistente = listaProductos.FirstOrDefault(p => p.id == producto.id);
            prodExistente.nombre = producto.nombre;
            prodExistente.categoria = producto.categoria;
            prodExistente.precio = producto.precio;
            prodExistente.stock = producto.stock;
            ViewBag.Mensaje = "Producto editado exitosamente.";
            return View(producto);
        }
    }
}