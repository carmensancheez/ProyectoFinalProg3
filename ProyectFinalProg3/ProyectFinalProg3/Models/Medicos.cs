using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectFinalProg3.Models
{
    public class Medicos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Exequatur { get; set; }
        public string Especialidad { get; set; }
    }
}