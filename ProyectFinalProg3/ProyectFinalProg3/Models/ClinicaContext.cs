using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProyectFinalProg3.Models
{
    public class ClinicaContext:DbContext
    {
        public ClinicaContext()
            : base("DBClinicaFinal")
        {
        }
        public DbSet <Pacientes> Pacientes { get; set; }
        public DbSet<Habitaciones> Habitaciones { get; set; }
        public DbSet<CitasMedicas> CitasMedicas { get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<Altas> Altas { get; set; }
    }
}