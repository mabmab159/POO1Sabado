using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Semana5.Controllers
{
    public class ProcesosController : Controller
    {
        int CantidadDivisores(int numero)
        {
            int cantidad = 0;
            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                {
                    cantidad++;
                }
            }
            return cantidad;
        }

        int SumaDivisores(int numero)
        {
            int suma = 0;
            for (int i = 1; i <= numero; i++)
            {
                if(numero % i == 0)
                {
                    suma += i;
                    //Hago una peticion hacia un tercero => API REST (1s)
                }
            }
            return suma;
        }

        int SumaDigitos(int numero)
        {
            int suma = 0;
            while(numero > 0)
            {
                int digito = numero % 10;
                suma += digito;
                numero /= 10;
            }
            return suma;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Operaciones(int numero = 0) //
        {
            ViewBag.CantidadDivisores = await Task.Run(() => CantidadDivisores(numero));
            ViewBag.SumaDivisores = await Task.Run(() => SumaDivisores(numero));
            ViewBag.SumaDigitos = await Task.Run(() => SumaDigitos(numero));
            return View();
        }
    }
}