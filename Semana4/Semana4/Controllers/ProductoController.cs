using Newtonsoft.Json;
using Semana4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana4.Controllers
{
    public class ProductoController : Controller
    {
        //JSON - JavaScript Object Notation
        // Al final es un texto estructurado con una sintaxis específica (llave, valor)
        // Mandando un JSON hacia un servicio
        // Estas recepcionando un JSON desde otro servicio
        static string productoJson = @"{
            'id': 1,
            'nombre': 'Laptop',
            'precio': 999.99,
            'stock': 10
        }";

        static string productoJsonLista = @"[
        {    'id': 1,
            'nombre': 'Laptop',
            'precio': 999.99,
            'stock': 10
        },
        {
            'id': 2,
            'nombre': 'Smartphone',
            'precio': 499.99,
            'stock': 20
        }]";

        public ActionResult Deserializar(int indice = 0)
        {
            try
            {
                Producto producto = JsonConvert.DeserializeObject<Producto>(productoJson);
                return View(producto); //null
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Hubo un error | Intentelo mas tarde";
                return View(new Producto());
            }
        }

        public ActionResult Serializar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Serializar(Producto producto)
        {
            string productoString = "";
            try
            {
                productoString = JsonConvert.SerializeObject(producto);
                ViewBag.ProductoString = productoString;
                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.ProductoString = "Hubo un error | Intentelo mas tarde";
                return View(new Producto());
            }
        }

        public ActionResult Index()
        {
            try
            {
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(productoJsonLista);
                return View(productos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Hubo un error | Intentelo mas tarde";
                return View(new List<Producto>());
            }
        }

        public ActionResult Create()
        {
            return View(new Producto());
        }


        //1. Recibir un producto desde la vista
        //2. Deserializar el arreglo
        //3. Agregar el nuevo producto al arreglo
        //4. Serializar el arreglo actualizado
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            try
            {
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(productoJsonLista);
                productos.Add(producto);
                productoJsonLista = JsonConvert.SerializeObject(productos);
                ViewBag.Mensaje = "Producto agregado correctamente";
                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Hubo un error | Intentelo mas tarde";
                return View(new Producto());
            }
        }

        public ActionResult Details(int id = 0)
        {
            try
            {
                //Deserealizando el arreglo
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(productoJsonLista);
                //Buscando el producto por id
                Producto producto = productos.Find(p => p.id == id);
                //Mando producto a la vista
                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Hubo un error | Intentelo mas tarde";
                return View(new Producto());
            }
        }
    }
}