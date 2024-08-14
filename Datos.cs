public class Datos
{
    private string casa, nombre, apodo, nacimiento;

    public Datos(string casa, string nombre, string apodo, string nacimiento)
    {
        this.casa = casa;
        this.nombre = nombre;
        this.apodo = apodo;
        this.nacimiento = nacimiento;
    }

    public string Casa
    {
        get => casa;
        set => casa = value; 
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
    public string Nacimiento
    {
        get => nacimiento;
        set => nacimiento = value; 
    }
}




