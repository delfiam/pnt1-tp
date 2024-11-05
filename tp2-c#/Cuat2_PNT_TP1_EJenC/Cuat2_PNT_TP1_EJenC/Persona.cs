using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

public class Persona
{
    private static long proxIdPersona = 1;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idPersona { get; set; }
    public string dni { get; set; }
    public string nombre { get; set; }
    


    //public Persona(string dni, string nombre)
    //{
    //    this.dni = dni;
    //    this.nombre = nombre;
    //    this.setIdPersona();
    //}
    /*private void setIdPersona() {
        this.idPersona = proxIdPersona;
        proxIdPersona ++;
    }
    */
    public override string ToString()
    {
        return $"ID: {idPersona} Nombre: {nombre} - DNI:{dni} ";
    }

}

