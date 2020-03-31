using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectFinalProg3.Models
{
    public class CitasMedicas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_Paciente { get; set; }
        [ForeignKey("Id_Paciente")]
        public Pacientes Pacientes { get; set; }

        [Required]
        public int Id_Medico { get; set; }
        [ForeignKey("Id_Medico")]
        public Medicos Medicos { get; set; }
        public string Fecha { get; set; }

        public string Hora { get; set; }
    }
}