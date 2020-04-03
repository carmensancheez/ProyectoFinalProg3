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
        public string Numero { get; set; }
        public TipoHab Tipo { get; set; }
        public double Precio { get; set; }

        public enum TipoHab
        {
            Doble,Privada,Suite
        }
    }
}