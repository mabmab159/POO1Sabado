using Semana4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana4.Controllers
{
    public class UsuarioController : Controller
    {
        //Nunca se debe dejar la cadena de conexión en el código, es una mala práctica riesgo de seguridad.
        //Se debe usar un archivo de configuración para esto.
        //string SQLConnectionString = "Data Source=localhost;Initial Catalog=Semana4;Integrated Security=True";

        IEnumerable<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            //SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Semana4;Integrated Security=True");

            //Especificar mi cadena de conexión en el archivo de configuración (Web.config) y luego usarla aquí.
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["baseDatos"].ConnectionString);

            //Abrir la conexión a la base de datos.
            connection.Open();

            //Crear un comando SQL
            SqlCommand command = new SqlCommand("SELECT * FROM Usuarios", connection);

            //Ejecutar el comando y obtener un lector de datos | Un sistema de grillas
            SqlDataReader sqlDataReader = command.ExecuteReader();

            //Leer los datos obtenidos del comando SQL
            while (sqlDataReader.Read())
            {
                Usuario usuarioAuxiliar = new Usuario
                {
                    Id = sqlDataReader.GetInt32(0),
                    Name = sqlDataReader.GetString(1),
                    Email = sqlDataReader.GetString(2),
                    FechaRegistro = sqlDataReader.GetDateTime(3)
                };
                usuarios.Add(usuarioAuxiliar);
            }

            return usuarios;
        }


        public ActionResult Index()
        {
            return View(ObtenerUsuarios());
        }
    }
}