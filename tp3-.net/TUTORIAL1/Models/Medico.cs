namespace TUTORIAL1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Especialidad
    {
        Cardiologia,
        Pediatria,
        Dermatologia,
        // otras especialidades
    }

    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Dni { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        public Especialidad Especialidad { get; set; }

        public ICollection<Turno>? Turnos { get; set; }
    }

}
