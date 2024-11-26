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

        [Required(ErrorMessage = "El DNI es requerido")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El DNI debe tener exactamente 8 dígitos.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Los NOMBRES y APELLIDOS son requeridos")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una especialidad")]
        public Especialidad Especialidad { get; set; }

        public ICollection<Turno>? Turnos { get; set; }
    }

}
