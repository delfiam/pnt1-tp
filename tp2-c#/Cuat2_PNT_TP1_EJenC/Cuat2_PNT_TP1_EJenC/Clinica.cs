using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuat2_PNT_TP1_EJenC
{
    internal class Clinica
    {
        private String nombre;
        private List<Medico> medicos;
        private List<Paciente> pacientes;
        private List<Turnera> turneras;

        public Clinica(string nombre)
        {
            this.nombre = nombre;
            medicos = new List<Medico>();
            pacientes = new List<Paciente>();
            turneras = new List<Turnera>();
        }

        public void abrirTurnera(string idTurnera) {
            this.turneras.Add(new Turnera(idTurnera));
        }
    }
}
