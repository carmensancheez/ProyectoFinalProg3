using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectFinalProg3.Models
{
    public class Ingresos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_Paciente { get; set; }
        [ForeignKey("Id_Paciente")]
        public Pacientes Pacientes { get; set; }

        [Required]
        public int Id_Habitacion { get; set; }
        [ForeignKey("Id_Habitacion")]
        public Habitaciones Habitaciones { get; set; }
        public string Fecha_Inicio { get; set; }
    }
}