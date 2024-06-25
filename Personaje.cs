public class Personaje
{
    //declaro datos privados
    private Datos datos;
    private Caracteristicas caracteristicas;

    //Constructor
    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        this.datos = datos;
        this.caracteristicas = caracteristicas;
    }

    //decalro propiedades públicas
    public Datos Datos
    {
        get => datos;
        set => datos = value;
    }

    public Caracteristicas Caracteristicas
    {
        get => caracteristicas;
        set => caracteristicas = value;
    }
}
