public class Datos
{
    private string tipo, nombre, apodo;
    private DateTime nacimiento;
    private int edad;

    public Datos(string tipo, string nombre, string apodo)
    {
        this.tipo = tipo;
        this.nombre = nombre;
        this.apodo = apodo;
    }

    public string Tipo
    {
        get => tipo;
        set => tipo = value; 
    }
    public string Nombre
    {
        get => nombre;
        set => nombre = value; 
    }
    public string Apodo
    {
        get => apodo;
        set => apodo = value; 
    }
    public DateTime Nacimiento
    {
        get => nacimiento;
        set => nacimiento = value; 
    }
    public int Edad
    {
        get => edad;
        set => edad = value; 
    }
}




