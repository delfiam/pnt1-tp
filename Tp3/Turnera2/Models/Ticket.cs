using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turnera2.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha {get; set; }
        
        public int MedicoId { get; set; }
        [ForeignKey("MedicoId")]
        [NotMapped]

        public Medico Medico { get; set; }
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        [NotMapped]
        public Paciente Paciente  { get; set; }

        /*
        public override string ToString()
        {
            Medico medico = AccesoADatos.BuscarMedico(medicoId);
            Paciente paciente = AccesoADatos.BuscarPaciente(pacienteId);
            return ($"-------------------------------------------- \n" +
                $"Turno: {fecha} / {hora} \n" +
                $"Especialidad: {Enum.GetName(typeof(Especialidad),medico.Especialidad)}\n" +
                $"Dr. {medico.NombreCompleto}\n" +
                $"Paciente: {paciente.NombreCompleto}\n" +
                $"Cobertura: {Enum.GetName(typeof(ObraSocial), paciente.ObraSocial)}\n");
        }
        */
    }
}