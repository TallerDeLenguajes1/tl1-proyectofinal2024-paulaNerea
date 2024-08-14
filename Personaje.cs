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

        public int Atacar(Personaje defensor)
        {

            int ataque = Caracteristicas.Destreza * Caracteristicas.Magia * Caracteristicas.Nivel;
            
            Random random = new Random();
            double efectividad = random.Next(1, 101);

            int defensa = defensor.Caracteristicas.Coraje * defensor.Caracteristicas.Velocidad;

            const int constanteDeAjuste = 500;

            double danio = ((ataque * efectividad)- defensa)/constanteDeAjuste;

            return Math.Max((int)danio, 0);        
        }

        public void RecibirDanio(int danio)
        {
            // Reduce la salud del personaje basado en el daño recibido
            Caracteristicas.Salud -= danio;

            // Asegurarse de que la salud no sea negativa
            if (Caracteristicas.Salud < 0)
            {
                Caracteristicas.Salud = 0;
            }
        }

        public void MostrarPersonaje()
        {
            // Define the width for the table
            int width = 50;

            // Define the header and content
            string header = "Datos del Personaje";
            string dataCasa = $"Casa: {Datos.Casa}";
            string dataNombre = $"Nombre: {Datos.Nombre}";
            string dataApodo = $"Apodo: {Datos.Apodo}";
            string dataNacimiento = $"Fecha de Nac: {Datos.Nacimiento}";

            string headerCaracteristicas = "Características del Personaje";
            string dataVelocidad = $"Velocidad: {Caracteristicas.Velocidad}";
            string dataDestreza = $"Destreza: {Caracteristicas.Destreza}";
            string dataMagia = $"Magia: {Caracteristicas.Magia}";
            string dataNivel = $"Nivel: {Caracteristicas.Nivel}";
            string dataCoraje = $"Coraje: {Caracteristicas.Coraje}";
            string dataSalud = $"Salud: {Caracteristicas.Salud}";

            // Create the table with borders
            string border = new string('-', width);
            Console.WriteLine(border);
            Console.WriteLine(AlignCenter(header, width));
            Console.WriteLine(border);
            Console.WriteLine(AlignCenter(dataCasa, width));
            Console.WriteLine(AlignCenter(dataNombre, width));
            Console.WriteLine(AlignCenter(dataApodo, width));
            Console.WriteLine(AlignCenter(dataNacimiento, width));
            Console.WriteLine(border);
            Console.WriteLine(AlignCenter(headerCaracteristicas, width));
            Console.WriteLine(border);
            Console.WriteLine(AlignCenter(dataVelocidad, width));
            Console.WriteLine(AlignCenter(dataDestreza, width));
            Console.WriteLine(AlignCenter(dataMagia, width));
            Console.WriteLine(AlignCenter(dataNivel, width));
            Console.WriteLine(AlignCenter(dataCoraje, width));
            Console.WriteLine(AlignCenter(dataSalud, width));
            Console.WriteLine(border);
        }

        // Method to center-align text within a given width
        private string AlignCenter(string text, int width)
        {
            int spaces = width - text.Length;
            if (spaces > 0)
            {
                int padLeft = spaces / 2;
                int padRight = spaces - padLeft;
                return new string(' ', padLeft) + text + new string(' ', padRight);
            }
            return text;
        }
    }
}