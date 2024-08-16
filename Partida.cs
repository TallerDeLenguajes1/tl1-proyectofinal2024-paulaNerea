using System;
using EspacioFabrica;
using EspaciodePersonaje;
using EspacioHistorial;
using EspaciodePersonajeJson;
using EspacioManejoApi;

namespace EspacioPartida
{
    public static class Juego
    {
        public static async Task Partida(Personaje personaje, List<Personaje> rivales)
        {
            foreach (var rival in rivales)
            {

                if (personaje.Caracteristicas.Salud <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{personaje.Datos.Nombre} ha sido derrotado y no puede continuar la batalla.");
                    break; // Termina la partida si el personaje ha sido derrotado
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine("********************************************************************************************************");
                Console.WriteLine($"*** ¡COMIENZA LA BATALLA ENTRE {personaje.Datos.Nombre.ToUpper()} Y {rival.Datos.Nombre.ToUpper()}! ***");
                Console.WriteLine("********************************************************************************************************");
                Console.ResetColor();

                Console.WriteLine("Presiona cualquier tecla para iniciar el combate...");
                Console.ReadKey();

                await Combate(personaje, rival);
                // Verifico si el personaje ha sido derrotado después del combate
                if (personaje.Caracteristicas.Salud <= 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"{personaje.Datos.Nombre} ha sido derrotado y no puede continuar la batalla.");
                    break; // Termina la partida si el personaje ha sido derrotado
                }

            }
             if (personaje.Caracteristicas.Salud > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("**************************************************************************************************");
                Console.WriteLine($"*** {personaje.Datos.Nombre.ToUpper()} HA DERROTADO A TODOS LOS RIVALES Y ES EL GANADOR FINAL ***");
                Console.WriteLine("**************************************************************************************************");
                Console.ResetColor();
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadKey();
            }
        }

        public static async Task Combate(Personaje personaje, Personaje rival)
        {
            while (personaje.Caracteristicas.Salud > 0 && rival.Caracteristicas.Salud > 0)
            {
                //Turno del personaje seleccionado
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine($"--- TURNO DE {personaje.Datos.Nombre.ToUpper()} ---");
                Console.ResetColor();
        
                int danio = personaje.Atacar(rival);
                rival.RecibirDanio(danio);
                Console.WriteLine($"{personaje.Datos.Nombre} inflige {danio} de daño a {rival.Datos.Nombre}. Salud restante: {rival.Caracteristicas.Salud}");

                if (rival.Caracteristicas.Salud <= 0)
                {
                    rival.Caracteristicas.Salud = 0; // Asegura que la salud no sea menor que 0
                    Console.WriteLine($"{rival.Datos.Nombre} ha sido derrotado.");
                    Console.WriteLine($"{personaje.Datos.Nombre} ha sobrevivido el combate. Obtiene +10 en salud.");
                    personaje.Caracteristicas.Salud += 10;//aplico mejora
                    break; // Termina el combate con este rival
                }

                var hechizo1 = await ManejoApi.GetRandomSpellAsync();
                if (hechizo1 != null)
                {
                    Console.WriteLine($"{personaje.Datos.Nombre} uso {hechizo1.spell}");
                }

                // Turno del rival
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine($"--- TURNO DE {rival.Datos.Nombre.ToUpper()} ---");
                Console.ResetColor();

                danio = rival.Atacar(personaje);
                personaje.RecibirDanio(danio);
                Console.WriteLine($"{rival.Datos.Nombre} inflige {danio} de daño a {personaje.Datos.Nombre}. Salud restante: {personaje.Caracteristicas.Salud}");

                if (personaje.Caracteristicas.Salud <= 0)
                {
                    personaje.Caracteristicas.Salud = 0; 
                    Console.WriteLine($"{personaje.Datos.Nombre} ha sido derrotado.");
                    break; 
                }

                var hechizo2 = await ManejoApi.GetRandomSpellAsync();
                if (hechizo2 != null)
                {
                    Console.WriteLine($"{rival.Datos.Nombre} uso {hechizo2.spell}");
                }

                Console.WriteLine($"-----------------------------------");
            }
            
        }
    }
}
