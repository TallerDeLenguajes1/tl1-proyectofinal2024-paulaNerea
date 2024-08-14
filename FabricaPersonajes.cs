using System;
using EspaciodePersonaje;

namespace EspacioFabrica
{

    public class FabricaPersonajes{
        //matriz con personjaes desponibles
        private static readonly string[,] personajesPredefinidos = new string[,]
        {
            { "Harry Potter", "El Elegido", "Gryffindor" },
            { "Hermione Granger", "La Cerebrito", "Gryffindor" },
            { "Ron Weasley", "El Amigo Fiel", "Gryffindor" },
            { "Draco Malfoy", "El Príncipe", "Slytherin" },
            { "Luna Lovegood", "La Excéntrica", "Ravenclaw" },
            { "Neville Longbottom", "El Valiente", "Gryffindor" },
            { "Ginny Weasley", "La Guerrera", "Gryffindor" },
            { "Severus Snape", "El Maestro de Pociones", "Slytherin" },
            { "Cedric Diggory", "El Justo", "Hufflepuff" },
            { "Cho Chang", "La Encantadora", "Ravenclaw" }
        };

        private static List<int> indicesDisponibles = new List<int>(); //lista para controlar los indices

        static FabricaPersonajes()
        {
            // Inicializar la lista de índices disponibles con todos los índices posibles
            for (int i = 0; i < personajesPredefinidos.GetLength(0); i++)
            {
                indicesDisponibles.Add(i);
            }
        }
        private static readonly Random random = new Random();
        public static Personaje CrearPersonaje() //
        {
            
            if (indicesDisponibles.Count == 0)
            {
                throw new InvalidOperationException("Todos los personajes posibles han sido generados.");
            }
            
            int randomIndex = random.Next(indicesDisponibles.Count);
            int index = indicesDisponibles[randomIndex];

            string nombre = personajesPredefinidos[index, 0];
            string apodo = personajesPredefinidos[index, 1];
            string casa = personajesPredefinidos[index, 2];

            // Eliminar el índice para que no se vuelva a utilizar
            indicesDisponibles.RemoveAt(randomIndex);

            // Generar una fecha de nacimiento aleatoria
            DateTime nacimiento = GenerarFechaAleatoria();

            Datos datos = new Datos(casa, nombre, apodo, nacimiento.ToString("yyyy-MM-dd"));

            int velocidad = random.Next(1, 11);
            int destreza = random.Next(1, 6);
            int fuerza = random.Next(1, 11);
            int nivel = random.Next(1, 11);
            int armadura = random.Next(1, 11);
            Caracteristicas caracteristicas = new Caracteristicas(velocidad, destreza, fuerza, nivel, armadura);

            return new Personaje(datos, caracteristicas);
        }

        private static DateTime GenerarFechaAleatoria()
        {
            Random random = new Random();
            DateTime start = new DateTime(1970, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
    }   
}
