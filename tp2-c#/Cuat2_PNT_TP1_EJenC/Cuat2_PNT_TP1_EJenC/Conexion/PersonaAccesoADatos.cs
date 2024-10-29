using Cuat2_PNT_TP1_EJenC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuat2_PNT_TP1_EJenC.Conexion
{
    internal class PersonaAccesoADatos
    {
        public static void AgregarPersona(Persona persona, Contexto contexto)
        {
            try {
                contexto.Personas.Add(persona);
                contexto.SaveChanges();
            } catch (Exception e) {
                throw e;
            }
        }
        public static string ListarPersona(Contexto contexto)
        {
          string lista = "";
            try {
                foreach (Persona persona in contexto.Personas) {
                    lista += persona.ToString() + "\n";
                }
            } catch (Exception e) {
                throw e;
            }
            return lista;
        } 
        public static void eliminarPersona (Persona persona, Contexto contexto)
        {
            try {
               var personaEliminar = contexto.Personas.Find(persona.idPersona);
               if (personaEliminar != null) {
                   contexto.Personas.Remove(personaEliminar);
                   contexto.SaveChanges();
               }
            else {
                throw new Exception("No se encontro la persona a eliminar");
            }
            } catch (Exception e) {
                throw e;
            }
        }
        public static void modificarPersona (Persona persona, Contexto contexto)
        {
            try {
                var personaModificar = contexto.Personas.Find(persona.idPersona);
                if (personaModificar != null) {
                    personaModificar.nombre = persona.nombre;
                    personaModificar.dni = persona.dni;
                    contexto.Personas.Update(personaModificar);
                    contexto.SaveChanges();
                }
                else {
                    throw new Exception("No se encontro la persona a modificar");
                }
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
