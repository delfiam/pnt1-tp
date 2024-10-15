using Cuat2_PNT_TP1_EJenC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Turnera
{
    private static int proximoNro = 1;
    private string idTurnera;
    private List<Ticket> turnos;

    public Turnera(String idTurnera)
    {
        idTurnera = idTurnera;
        turnos = new List<Ticket>();
    }

    public string IdTurnera
    {
        get { return idTurnera; }
    }

    public void DarTurno(int nroTurno, DateOnly fecha, TimeOnly hora, string nombreMedico, string nombrePaciente, Especialidad especialidad)
    {
        this.turnos.Add(new Ticket (proximoNro, fecha, hora, nombreMedico, nombrePaciente, especialidad));
               
        Turnera.proximoNro++;
    }

    public void llamarTurno()
    {
        Ticket llamar = this.turnos[0];

        Console.WriteLine($"turnera:  {idTurnera}");
        llamar.llamarTurno();
                
        

    }
}
