namespace Turnera2.Models
{
    public class TicketViewModel
    {
        public int TicketId { get; set; }
        public DateTime Fecha { get; set; }
        public String EspecialString { get;set; }   

        public string MedicoNombreCompleto { get; set; }
        public string PacienteNombreCompleto { get; set; }
    }
}
