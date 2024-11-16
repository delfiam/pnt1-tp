using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnera2.Models;

namespace Turnera2.Models
{
    public class ClinicaContexto : DbContext
    {
        public ClinicaContexto(DbContextOptions<ClinicaContexto> options) : base(options) 
        { 
        }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurar la relación entre Turno(Ticket) y Medico
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Medico) // Un Turno tiene un Medico
                .WithMany() // Un Medico puede tener muchos Turnos
                .HasForeignKey(t => t.MedicoId); // La clave foránea es MedicoId 

            // Configurar la relación entre Turno(Ticket) y Paciente
            modelBuilder.Entity <Ticket>() .HasOne(t => t.Paciente) // Un Turno tiene un Paciente
            .WithMany() // Un Paciente puede tener muchos Turnos
            .HasForeignKey(t => t.PacienteId); // La clave foránea es PacienteId
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DELFIS-PC;Database=CLINICA;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        

    }
}
