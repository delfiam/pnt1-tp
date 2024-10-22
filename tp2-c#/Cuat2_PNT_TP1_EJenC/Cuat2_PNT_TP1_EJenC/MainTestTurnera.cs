using Cuat2_PNT_TP1_EJenC.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuat2_PNT_TP1_EJenC
{
    internal class MainTestTurnera
    {
        static void Main(string[] args)
        {
            var conexion = new Contexto();  // Contexto existente

            // Crear y agregar un nuevo paciente
            var nuevoPaciente = new Paciente
            {
                dni = "12345678",
                nombre = "Juan Perez",
                obraSocial = ObraSocial.MEDICUS
            };

            PacienteAccesoADatos.AgregarPaciente(nuevoPaciente, conexion);

            // Listar pacientes
            Console.WriteLine(PacienteAccesoADatos.ListarPacientes(conexion));
        }
    }
}