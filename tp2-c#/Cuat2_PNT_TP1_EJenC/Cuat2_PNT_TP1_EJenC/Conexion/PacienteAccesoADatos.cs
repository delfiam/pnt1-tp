using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuat2_PNT_TP1_EJenC.Conexion
{
    internal class PacienteAccesoADatos
    {
        public static void AgregarPaciente(Paciente paciente,Contexto contexto)
        {
            try
            {
                contexto.Pacientes.Add(paciente);
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + e.InnerException.Message);
                }
                throw;
            }

        }
        public static string ListarPacientes(Contexto contexto)
        {
            string lista = "";
            try
            {
                foreach (Paciente paciente in contexto.Pacientes)
                {
                    lista += paciente.ToString() + "\n";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return lista;
        }
        public static void eliminarPaciente(Paciente paciente, Contexto contexto)
        {
            try
            {
                var pacienteEliminar = contexto.Pacientes.Find(paciente.idPersona);
                if (pacienteEliminar != null)
                {
                    contexto.Pacientes.Remove(pacienteEliminar);
                    contexto.SaveChanges();
                }
                else
                {
                    throw new Exception("No se encontro el paciente a eliminar");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void modificarPaciente(Paciente paciente, Contexto contexto)
        {
            try
            {
                var pacienteModificar = contexto.Pacientes.Find(paciente.idPersona);
                if (pacienteModificar != null)
                {
                    pacienteModificar.nombre = paciente.nombre;
                    pacienteModificar.dni = paciente.dni;
                    pacienteModificar.obraSocial = paciente.obraSocial;
                    contexto.Pacientes.Update(pacienteModificar);
                    contexto.SaveChanges();
                }
                else
                {
                    throw new Exception("No se encontro el paciente a modificar");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
