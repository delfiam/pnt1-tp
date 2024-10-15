using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuat2_PNT_TP1_EJenC
{
    internal class MainTestTurnera { 
        static void Main(string[] args) {

            Paciente pac = new Paciente("24717182", "emiliano", ObraSocial.GALENO);
            Medico med = new Medico("21342134", "Dalmacio Velez Sarfield", Especialidad.OFTALMO);



            Console.WriteLine(pac.ToString());
            Console.WriteLine(med.ToString());
        }

    }

}
