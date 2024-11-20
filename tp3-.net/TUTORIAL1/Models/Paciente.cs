namespace TUTORIAL1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum ObraSocial
    {
        OSDE,
        SwissMedical,
        Galeno,
        // otras obras sociales
    }

    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Dni { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        public ObraSocial ObraSocial { get; set; }

        public ICollection<Turno>? Turnos { get; set; }
    }

}
