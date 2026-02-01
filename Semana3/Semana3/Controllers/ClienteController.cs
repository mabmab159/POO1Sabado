using Semana3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Controllers
{
    public class ClienteController : Controller
    {
        static List<Cliente> listaClientes  = new List<Cliente>()
        {
            new Cliente(){ dni="70456789", nombre="Juan", apellido="Perez", direccion="Av. Siempre Viva 123", telefono="987654321"},
            new Cliente(){ dni="70567890", nombre="Maria", apellido="Gomez", direccion="Calle Falsa 456", telefono="912345678"},
            new Cliente(){ dni="70678901", nombre="Luis", apellido="Rodriguez", direccion="Jiron Los Olivos 789", telefono="923456789"},
        };

        public async Task<ActionResult> Index()
        {
            return View(await Task.Run(() => listaClientes));
        }

        public async Task<ActionResult> Filtro(string nombre="")
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return View(await Task.Run(() => new List<Cliente>()));
            }
            var listaFiltrada = await Task.Run(() => listaClientes.Where(e => e.nombre.StartsWith(nombre)));
            return View(listaFiltrada);
        }

        public async Task<ActionResult> Create()
        {
            return View(await Task.Run(() =>new Cliente()));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            if(!ModelState.IsValid)
            {
                return View(await Task.Run(() =>cliente));
            }
            listaClientes.Add(cliente);
            ViewBag.Mensaje = "Cliente registrado correctamente";
            return View(await Task.Run(() => cliente));
        }
    }
}