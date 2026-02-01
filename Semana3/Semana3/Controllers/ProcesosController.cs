using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Controllers
{
    public class ProcesosController : Controller
    {
        private int CantidadDivisores (int numero)
        {
            int contador = 0;
            for (int i = 1; i <= numero; i++)
            {
                if(numero % i == 0)
                {
                    contador++;
                }
            }
            return contador;
        }

        private int SumaDivisores (int numero)
        {
            int suma = 0;
            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                {
                    suma+=i;
                }
            }
            return suma;
        }

        private int SumaDigitos (int numero)
        {
            int suma = 0;
            while (numero > 0)
            {
                suma += numero % 10;
                numero /= 10;
            }
            return suma;
        }

        public async Task<ActionResult> Operaciones(int numero = 0)
        {
            ViewBag.CantidadDivisores = await Task.Run(() => CantidadDivisores(numero));
            ViewBag.SumaDivisores = await Task.Run(() => SumaDivisores(numero));
            ViewBag.SumaDigitos = await Task.Run(() => SumaDigitos(numero));
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}