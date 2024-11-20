namespace TUTORIAL1.Context
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TUTORIAL1.Models;

    public class TurnoDbContext : DbContext
    {
        public TurnoDbContext(DbContextOptions<TurnoDbContext> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Turno> Turnos { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Medico)
                .WithMany(m => m.Turnos)
                .HasForeignKey(t => t.MedicoId);

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Paciente)
                .WithMany(p => p.Turnos)
                .HasForeignKey(t => t.PacienteId);
        }   
    }

}
