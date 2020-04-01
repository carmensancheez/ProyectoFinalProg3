using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectFinalProg3.Models
{
    public class Altas
    {
        [Key]
        public int Id { get; set; }
        public double Monto { get; set; }

        [Required]
        public int Id_Ingreso { get; set; }
        [ForeignKey("Id_Ingreso")]
        public Ingresos Ingresos { get; set; }
        public string Fecha_Salida { get; set; }

        public string Nombre_Paciente { get; set; }
        public int IumHabitacion { get; set; }
        public string Fecha_Inicio { get; set; }

        public double Monto_Final { get; set; }
    }
}