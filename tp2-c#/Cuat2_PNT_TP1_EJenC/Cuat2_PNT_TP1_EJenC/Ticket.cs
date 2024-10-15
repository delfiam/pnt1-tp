using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuat2_PNT_TP1_EJenC
{
    internal class Ticket
    {
        private int nroTurno;
        private String nombrePaciente;
        private String nombreMedico;
        private Especialidad especialidad;
        private DateOnly fecha;
        private TimeOnly hora;
        
        public Ticket (int nroTurno, DateOnly fecha, TimeOnly hora, String nombreMedico, String nombrePaciente, Especialidad especialidad)
        {
            this.nroTurno = nroTurno;
            this.nombrePaciente = nombrePaciente;
            this.nombreMedico = nombreMedico;
            this.especialidad = especialidad;
            this.fecha = fecha;
            this.hora = hora;

        }

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
