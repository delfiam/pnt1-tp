using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuat2_PNT_TP1_EJenC
{
    internal class MainTestTurnera { 
        static void Main(string[] args) {

            Paciente pac = new Paciente() { dni = "12345678", nombre = "Juan Perez", obraSocial = ObraSocial.OSDE };
            Medico med = new Medico() { dni = "87654321", nombre = "Dr. Juan Lopez", especialidad = Especialidad.DERMATOLOGIA };



            Console.WriteLine(pac.ToString());
            Console.WriteLine(med.ToString());
        }

    }

}
