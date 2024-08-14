using System;

namespace EspaciodePersonaje
{

    public class FabricaPersonajes{
        private static readonly Random random = new();

        //creo una lista de tipo datos que tenga nomre, apodos, y otros datos especificos de un personaje 
        private static List<Datos> HPpersonajes = new List<Datos>
        {
            new Datos("Mago", "Harry Potter", "El Niño que Vivió"),
            new Datos("Maga", "Hermione Granger", "La Más Brillante"),
            new Datos("Mago", "Ron Weasley", "El Valiente"),
            new Datos("Mago", "Draco Malfoy", "El Heredero"),
            new Datos("Mago", "Albus Dumbledore", "El Sabio")
        };
        public static Personaje CrearPersonaje() //
        {
            //se elige un personaje de un indice random entre 0 y la cantidad de elementos de la lista
            Datos datos = HPpersonajes[random.Next(HPpersonajes.Count)];

            int velocidad = random.Next(1, 11);
            int destreza = random.Next(1, 6);
            int fuerza = random.Next(1, 11);
            int nivel = random.Next(1, 11);
            int armadura = random.Next(1, 11);
            Caracteristicas caracteristicas = new Caracteristicas(velocidad, destreza, fuerza, nivel, armadura);

            return new Personaje(datos, caracteristicas);
        }  

    }   
}
