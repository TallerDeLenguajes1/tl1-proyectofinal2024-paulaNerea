namespace EspaciodePersonaje
{
    public class Personaje
    {
        private Datos datos;
        private Caracteristicas caracteristicas;

        public Personaje(Datos datos, Caracteristicas caracteristicas)
        {
            this.datos = datos;
            this.caracteristicas = caracteristicas;
        }

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

        public void MostrarPersonaje()
        {
            Console.WriteLine("Datos del Personaje:");
            Console.WriteLine("Tipo: " + Datos.Tipo);
            Console.WriteLine("Nombre: " + Datos.Nombre);
            Console.WriteLine("Apodo: " + Datos.Apodo);

            Console.WriteLine("\nCaracterísticas del Personaje:");
            Console.WriteLine("Velocidad: " + Caracteristicas.Velocidad);
            Console.WriteLine("Destreza: " + Caracteristicas.Destreza);
            Console.WriteLine("Fuerza: " + Caracteristicas.Fuerza);
            Console.WriteLine("Nivel: " + Caracteristicas.Nivel);
            Console.WriteLine("Armadura: " + Caracteristicas.Armadura);
            Console.WriteLine("Salud: " + Caracteristicas.Salud);

        }
    }
}