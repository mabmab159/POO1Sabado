using Semana6.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana6.Controllers
{
    public class ClienteController : Controller
    {
        IEnumerable<Cliente> obtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baseDatos"].ConnectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("usp_Clientes", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                clientes.Add(new Cliente()
                {
                    id = sqlDataReader.GetString(0),
                    nombre = sqlDataReader.GetString(1),
                    direccion = sqlDataReader.GetString(2),
                    pais = sqlDataReader.GetString(3),
                    telefono = sqlDataReader.GetString(4),
                });
            }

            sqlDataReader.Close();
            sqlConnection.Close();

            return clientes;
        }

        IEnumerable<Cliente> obtenerClientes(string nombre)
        {
            List<Cliente> clientes = new List<Cliente>();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baseDatos"].ConnectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("usp_Clientes_Filtro_Nombre", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@nombre", nombre);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                clientes.Add(new Cliente()
                {
                    id = sqlDataReader.GetString(0),
                    nombre = sqlDataReader.GetString(1),
                    direccion = sqlDataReader.GetString(2),
                    pais = sqlDataReader.GetString(3),
                    telefono = sqlDataReader.GetString(4)
                });
            }

            sqlDataReader.Close();
            sqlConnection.Close();

            return clientes;
        }

        string crearCliente(Cliente cliente)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baseDatos"].ConnectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("usp_Crear_Cliente", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", cliente.id);
            sqlCommand.Parameters.AddWithValue("@nombre", cliente.nombre);
            sqlCommand.Parameters.AddWithValue("@direccion", cliente.direccion);
            sqlCommand.Parameters.AddWithValue("@pais", cliente.pais);
            sqlCommand.Parameters.AddWithValue("@telefono", cliente.telefono);

            int cantidadFilas = sqlCommand.ExecuteNonQuery();
            //return "Se ha creado " + cantidadFilas + " de filas";
            return $"Se ha creado {cantidadFilas} de filas";
        }

        Cliente obtenerClientePorId(string id)
        {
            Cliente cliente = new Cliente();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baseDatos"].ConnectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("usp_Buscar_Cliente", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                cliente = new Cliente()
                {
                    id = sqlDataReader.GetString(0),
                    nombre = sqlDataReader.GetString(1),
                    direccion = sqlDataReader.GetString(2),
                    pais = sqlDataReader.GetString(3),
                    telefono = sqlDataReader.GetString(4),
                };
            }
            return cliente;
        }

        public ActionResult Index()
        {
            return View(obtenerClientes());
        }

        public ActionResult Create()
        {
            return View(new Cliente());
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            //Agregar logica para guardar cliente
            ViewBag.Mensaje = crearCliente(cliente);
            return View(cliente);
        }

        public ActionResult Details(string id)
        {
            return View(obtenerClientePorId(id));
        }

        public ActionResult Filtro(string nombre = "") {
            var resultados = obtenerClientes(nombre);
            return View(resultados);
        }
    }
}