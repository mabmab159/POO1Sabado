using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public class Curso
    {
        [Key] public int id { get; set; }
        [DisplayName("Nombre")] public string nombre { get; set; }
        [DisplayName("Creditos")] public int creditos { get; set; }
    }
}