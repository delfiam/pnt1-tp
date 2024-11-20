using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnera2.Models
{
    public class Medico    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Dni { get; set; }
        public string NombreCompleto { get; set; }
        public Especialidad Especialidad { get; set; }
       
    }
}
