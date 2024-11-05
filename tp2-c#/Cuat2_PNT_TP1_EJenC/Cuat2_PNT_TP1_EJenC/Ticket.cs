using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuat2_PNT_TP1_EJenC
{
    internal class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nroTurno { get; set; }
        public String nombrePaciente { get; set; }
        public String nombreMedico { get; set; }
        public Especialidad especialidad { get; set; }
        public DateOnly fecha { get; set; }
        public TimeOnly hora { get; set; }

        /* public Ticket (int nroTurno, DateOnly fecha, TimeOnly hora, String nombreMedico, String nombrePaciente, Especialidad especialidad)
         {
             this.nroTurno = nroTurno;
             this.nombrePaciente = nombrePaciente;
             this.nombreMedico = nombreMedico;
             this.especialidad = especialidad;
             this.fecha = fecha;
             this.hora = hora;

         } */

        public void llamarTurno()
        {
            Console.WriteLine($"Turno {nroTurno} asignado:");
            Console.WriteLine($"Especialidad: {especialidad}");
        }
        
        public override String ToString() {
            return String.Format("NRO: {0}\nFECHA: {1}\nHORA: {2}\nPACIENTE: {3}\nDOCTOR: {4}\nPRACTICA: {5}",
                                    nroTurno, fecha, hora, nombrePaciente, nombreMedico, especialidad);
                }
    }
}
