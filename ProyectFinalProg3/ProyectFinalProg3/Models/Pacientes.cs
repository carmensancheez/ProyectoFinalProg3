using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectFinalProg3.Models
{
    public class Pacientes
    {
        [Key]
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public bool Asegurado { get; set; }
    }
}