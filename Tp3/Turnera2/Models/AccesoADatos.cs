using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnera2.Models
{
    public class AccesoADatos
    {
        /*
        public static void VaciarBase()
        {
            var contexto = new ClinicaContexto();
            foreach (var item in contexto.Medicos)
            {
                contexto.Medicos.Remove(item);

            }
            foreach (var item in contexto.Pacientes)
            {
                contexto.Pacientes.Remove(item);
            }
            foreach (var item in contexto.Tickets)
            {
                contexto.Tickets.Remove(item);
            }
            contexto.SaveChangesAsync();
        }


        public static void Agregar(ClinicaContexto conexion, Medico Medico)
        {
            try
            {
                conexion.Medicos.Add(Medico);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;    // reenvía la exception para mostrarla en el Program
            }
        }

        public static void Agregar(ClinicaContexto conexion, Paciente Paciente)
        {
            try
            {
                conexion.Pacientes.Add(Paciente);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;    // reenvía la exception para mostrarla en el Program
            }
        }

        public static void Agregar(ClinicaContexto conexion, Ticket ticket)
        {
            try
            {
                conexion.Tickets.Add(ticket);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;    // reenvía la exception para mostrarla en el Program
            }
        }


        public static string ListarMedicos(ClinicaContexto conexion)
        {
            string? resultado = "";

            if (conexion.Medicos.Count() > 0)   //Si no hay estudiantes, retorna cadena vacía
            {
                resultado = "Listado de Estudiantes\n";

                foreach (var item in conexion.Medicos)
                {
                    resultado += $"ID {item.PersonaId} {item.NombreCompleto} {item.Especialidad}\n";
                }
            }
            return resultado;
        }

        public static string ListarPacientes(ClinicaContexto conexion)
        {
            string? resultado = "";

            if (conexion.Pacientes.Count() > 0)   //Si no hay estudiantes, retorna cadena vacía
            {
                resultado = "Listado de Pacientes\n";

                foreach (var item in conexion.Pacientes)
                {
                    resultado += $"ID {item.PersonaId} {item.NombreCompleto} {item.ObraSocial}\n";
                }
            }
            return resultado;
        }

        public static Medico BuscarMedico(int medicoId)
        {
            var contexto = new ClinicaContexto();
            Medico encontrado;

            try
            {
                encontrado = contexto.Medicos.Where(elemen => elemen.PersonaId == medicoId).FirstOrDefault();
                if (encontrado == null)
                {
                    throw new Exception($" EL Médico con ID {medicoId} no existe en Base");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return encontrado;
        }

        public static Paciente BuscarPaciente(int pacienteId)
        {
            var contexto = new ClinicaContexto();
            Paciente encontrado;

            try
            {
                encontrado = contexto.Pacientes.Where(elemen => elemen.PersonaId == pacienteId).FirstOrDefault();
                if (encontrado == null)
                {
                    throw new Exception($" EL Paciente con ID {pacienteId} no existe en Base");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return encontrado;
        }

        internal static string ListarTickets()
        {
            var conexion = new ClinicaContexto();
            string? resultado = "";

            if (conexion.Tickets.Count() > 0)   //Si no hay estudiantes, retorna cadena vacía
            {
                resultado = "Listado de Pacientes\n";

                foreach (var item in conexion.Tickets)
                {
                    resultado += item.ToString();
                }
            }
            return resultado;
        }*/
    }
}
