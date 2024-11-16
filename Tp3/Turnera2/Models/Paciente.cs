using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnera2.Models
{
    public class Paciente

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Dni { get; set; }
        public string NombreCompleto { get; set; }
        public ObraSocial ObraSocial { get; set; }
          

        
    }

}
