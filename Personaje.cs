namespace EspaciodePersonaje
{
    public class Personaje
    {
        //campo privado para almacenar los datos del personaje
        private Datos datos;
        //campo privado para almacenar las caracteristicas del personaje
        private Caracteristicas caracteristicas;

        public Personaje(Datos datos, Caracteristicas caracteristicas)
        {
            this.datos = datos;
            this.caracteristicas = caracteristicas;
        }


        public Datos Datos
        {
            get => datos;
        }

        public Caracteristicas Caracteristicas
        {
            get => caracteristicas;
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