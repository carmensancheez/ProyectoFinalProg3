using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectFinalProg3.Models
{
    public class Habitaciones
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public double Precio { get; set; }
    }
}