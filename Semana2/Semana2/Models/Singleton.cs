using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public class Singleton
    {
        private static Singleton instancia; //Atributo estatica para guardar la unica instancia

        private Singleton()
        { // Constructor vacio - No va a permitir crear instancias desde fuera
        }

        //Crear o gestionar esa primera o unica instancia
        public static Singleton GetInstancia()
        {
            if(instancia == null)
            {
                instancia = new Singleton();
            }
            return instancia;
        }
    }
}