using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuat2_PNT_TP1_EJenC.Conexion
{
    internal class Contexto : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .ToTable("Pacientes")
                .Property(p => p.obraSocial)
        .HasConversion<string>();


            modelBuilder.Entity<Ticket>()
                .ToTable("Tickets")
                  .HasKey(p => p.nroTurno);

            modelBuilder.Entity<Medico>()
                .ToTable("Medicos")
                .Property(p => p.especialidad)
        .HasConversion<string>();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2N6B5NK\\SQLEXPRESS;Database=TURNERA;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}