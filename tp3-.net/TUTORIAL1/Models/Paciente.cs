namespace TUTORIAL1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum ObraSocial
    {
        OSDE,
        [Display(Name = "Swiss Medical")]
        SwissMedical,
        Galeno,
        // otras obras sociales
    }

    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El DNI es requerido")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El DNI debe tener exactamente 8 dígitos.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una obra social")]
        public ObraSocial ObraSocial { get; set; }

        public ICollection<Turno>? Turnos { get; set; }
    }

}
