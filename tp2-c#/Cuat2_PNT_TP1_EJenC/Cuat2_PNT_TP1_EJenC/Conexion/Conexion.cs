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
        public DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2N6B5NK\\SQLEXPRESS.;Database=TURNERA;Trusted_Connection=True;");
        }   
    }
}
