namespace TUTORIAL1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Turno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Día y Hora")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un medico")]
        public int MedicoId { get; set; }

        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un paciente")]
        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }
    }

}
