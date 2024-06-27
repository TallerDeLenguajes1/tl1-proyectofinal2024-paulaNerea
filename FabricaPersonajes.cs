using System;
namespace EspaciodePersonaje
{
    public class FabricaPersonajes{
        private static Random random = new Random();
        public static Personaje CrearPersonaje() //
        {
            string tipo = "Tipo"; 
            string nombre = "Nombre";
            string apodo = "Apodo";
            Datos datos = new Datos(tipo, nombre, apodo);

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
