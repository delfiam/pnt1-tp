using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Medico : Persona
{
    public Especialidad especialidad { get; set;}

    // Constructor
    //public Medico(string dni, string nombre, Especialidad especialidad)
    //    : base(dni, nombre)
    //{
    //    this.especialidad = especialidad;
    //}

    // Propiedad pública para acceso a la especialidad
    //public Especialidad Especialidad
    //{
    //    get { return especialidad; }
    //    set { especialidad = value; }
    //}
}