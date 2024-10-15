public class Paciente : Persona
{
    private ObraSocial obraSocial;

    // Constructor
    //public Paciente (string dni, string nombre, ObraSocial obraSocial)
    //    : base(dni, nombre)
    //{
    //    this.obraSocial = obraSocial;
    //}

    public ObraSocial getObraSocial()
    {
        return this.obraSocial;
    }

    public String getDni()
    {
        return this.dni;

    }
    public override string ToString()
    {
        return base.ToString() + $"Obra Social: {obraSocial}";
    }
}
