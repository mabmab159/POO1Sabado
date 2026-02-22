using Newtonsoft.Json;
using Semana5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana5.Controllers
{
    public class ProveedorController : Controller
    {
        static List<Proveedor> proveedores = new List<Proveedor>();
        string carpeta = "~/carpeta/";

        public ActionResult Index()
        {
            //Para abrir | Ubicar un archivo
            FileStream fileStream = new FileStream($"{Server.MapPath(carpeta)}lista.json", FileMode.Open);
            //Crear un StreamReader para leer el contenido del archivo
            StreamReader streamReader = new StreamReader(fileStream);
            proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(streamReader.ReadToEnd());

            streamReader.Close();
            fileStream.Close();
            return View(proveedores);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        {
            string ruta = $"{Server.MapPath(carpeta)}lista.json";

            //Paso 1. Validar el archivo
            if (!System.IO.File.Exists($"{Server.MapPath(carpeta)}lista.json"))
            {
                return View();
            }

            //Paso 2. Crear un FileStream para abrir | Ubicar el archivo (Modo: Open)
            FileStream fileStream = new FileStream(ruta, FileMode.Open);

            //Paso 3. Crear un StreamReader para leer el contenido del archivo
            StreamReader streamReader = new StreamReader(fileStream);

            //Paso 4. Desearializando el contenido del archivo y asignandolo a la variable
            proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(streamReader.ReadToEnd());

            //Paso 5. Crear el StreamReader y el FileStream
            streamReader.Close();
            fileStream.Close();

            //Paso 6. Agregar el nuevo proveedor a la lista de proveedores
            proveedores.Add(proveedor);

            //Paso 7. Serializar la lista de proveedores
            string cadenaSerializada = JsonConvert.SerializeObject(proveedores);

            //Paso 8. Crear un FileStream para escribir el contenido (Modo: Create)
            fileStream = new FileStream(ruta, FileMode.Create);

            //Paso 9. Crear un StreamWriter para escribir el contenido en el archivo
            StreamWriter streamWriter = new StreamWriter(fileStream);

            //Paso 10. Escribir la cadena de texto (serializado) en el archivo
            streamWriter.Write(cadenaSerializada);

            //Paso 11. Cerar el StreamWriter y el FileStream
            streamWriter.Close();
            fileStream.Close();

            ViewBag.Mensaje = "Proveedor registrado correctamente";

            return View(proveedor);
        }
    }
}