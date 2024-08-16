using System;
using EspacioFabrica;
using EspaciodePersonaje;
using EspacioHistorial;
using EspaciodePersonajeJson;
using EspacioPartida;

class Program
    {
        static async Task Main(string[] args)
        {
            string archivoPersonajes = "personajes.json";
            string archivoGanadores = "ganadores.json";

            bool continuar = true;

            while (continuar)
            {
                MostrarMenu();
                int opcion = ObtenerOpcion();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Iniciando Nueva Partida...");
                        await NuevaPartida(archivoPersonajes, archivoGanadores);
                        break;

                    case 2:
                        Console.WriteLine("Mostrando Lista de Ganadores...");
                        MostrarGanadores(archivoGanadores);
                        break;

                    case 3:
                        continuar = false;
                        Console.WriteLine("Gracias por jugar al 'Torneo de los 3 Magos'!");
                        Console.WriteLine("Vuelvas prontos!");
                        Console.WriteLine("Saliendo del juego...");
                        break;
                }
            }


        }

        static void MostrarIntroduccion()
        {
             Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("               Nueva Partida");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("¡Bienvenido al 'Torneo de los 3 Magos'!");
            Console.WriteLine("En este emocionante torneo, tendrás la oportunidad de competir en uno de los eventos más prestigiosos de Hogwarts.");
            Console.WriteLine("Elige a tu mago y enfréntalo en una serie de duelos épicos contra otros campeones.");
            Console.WriteLine("Cada duelo es un enfrentamiento por turnos donde deberás demostrar tu habilidad mágica y estrategia.");
            Console.WriteLine("El combate continúa hasta que uno de los magos pierda toda su salud. El perdedor será eliminado del torneo.");
            Console.WriteLine("El mago que sobreviva a todos sus rivales y gane la final será coronado campeón de 'La Copa de los Tres Magos'.");
            Console.WriteLine("¿Tienes lo necesario para triunfar y convertirte en el campeón absoluto?");
            Console.WriteLine("¡Elige sabiamente y prepárate para demostrar tu maestría mágica!");
            Console.WriteLine(" ");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();  // Pausa y espera a que el usuario presione una tecla

        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("****************************************");
            Console.WriteLine("*          'TORNEO DE LOS 3 MAGOS'      *");
            Console.WriteLine("****************************************");
            Console.WriteLine("*              MENÚ PRINCIPAL           *");
            Console.WriteLine("****************************************");
            Console.WriteLine("* 1. Nueva Partida                      *");
            Console.WriteLine("* 2. Mostrar Ganadores                  *");
            Console.WriteLine("* 3. Salir                              *");
            Console.WriteLine("****************************************");
            Console.WriteLine();
        }

        static int ObtenerOpcion()
        {
            int opcion;
            while (true) //hasta que se ingrese una opcion valida
            {
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 3) //int.TryParse convierte la entrada del usuario (cadena de texto) a un número entero (int).
                {                                                                               //Devuelve true si la conversión es exitosa, y almacena el resultado en la variable opcion. Si falla, opcion no se actualiza.
                    return opcion;
                }
                Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 3.");
            }
        }
        
        static async Task NuevaPartida(string archivoPersonajes, string archivoGanadores)
        {
            MostrarIntroduccion();
            List<Personaje> personajes;

            // Verifica si el archivo JSON de personajes existe
            if (PersonajesJson.Existe(archivoPersonajes))
            {
                // Si existe, lee los personajes del archivo y los guarda en la lista "personajes"
                personajes = PersonajesJson.LeerPersonajes(archivoPersonajes);
            }
            else
            {
                // Si no existe, crea personajes con la fábrica de personajes y los guarda en el JSON
                personajes = new List<Personaje>();
                for (int i = 0; i < 3; i++)
                {
                    // Crea un personaje usando la fábrica
                    Personaje personaje = FabricaPersonajes.CrearPersonaje();
                    // Agrega el personaje a la lista
                    personajes.Add(personaje);
                }

                Console.WriteLine();
                PersonajesJson.GuardarPersonajes(personajes, archivoPersonajes);
                Console.WriteLine("Se crearon nuevos personajes y se guardaron en el archivo.");
                Console.WriteLine();
            }

            MostrarPersonajesDisponibles(personajes);
            Console.WriteLine("Elija su personje (Ingrese su ID)");
            int seleccion;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out seleccion) && seleccion > 0 && seleccion <= personajes.Count)
                {
                    // Convertir la selección a índice 
                    seleccion--; 
                    break;
                }
                else
                {
                    Console.WriteLine("Selección inválida. Por favor, elija un número entre 1 y " + personajes.Count + ":");
                }
            }
    
            Personaje seleccionado = personajes[seleccion]; //personaje del usuario
            List<Personaje> rivales = new(personajes); //lista de rivales copiando la lista personajes
            rivales.RemoveAt(seleccion); //elimino el personaje seleccionado de la lista de rivales

            await Juego.Partida(seleccionado, rivales);

            if (seleccionado.Caracteristicas.Salud > 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("***********************************************************************");
                Console.WriteLine($"{seleccionado.Datos.Nombre} es el digno merecedor de la Copa de los 3 Magos");
                Console.WriteLine("***********************************************************************");

                HistorialJson.GuardarGanador(seleccionado, archivoGanadores );
                Console.WriteLine("Presiona cualquier tecla para continuar.");
                Console.ReadKey();

            }else
            {
                Console.WriteLine("GAME OVER");
            }
            Console.WriteLine(" ");
            Console.WriteLine("---Fin de la Partida---");
            Console.WriteLine("\nPresiona cualquier tecla para volver al menú principal...");
            Console.ReadKey();

        }

        static void MostrarPersonajesDisponibles(List<Personaje> personajes)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Magos elegidos por el Caliz de Fuego: ");
            for (int i = 0; i < personajes.Count; i++)
            {
                // Mostrar el índice del personaje (i + 1 para que empiece en 1 en lugar de 0)
                Console.WriteLine(" ");
                Console.WriteLine($"[{i + 1}]");
                // Mostrar los detalles del personaje
                personajes[i].MostrarPersonaje();
            }
        }

        static void MostrarGanadores(string archivoGanadores)
        {
            if (HistorialJson.Existe(archivoGanadores))
            {
                List<Personaje> ganadores = HistorialJson.LeerGanadores(archivoGanadores);
                if (ganadores.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("**************************************************");
                    Console.WriteLine("*** HISTORIAL DE GANADORES ***");
                    Console.WriteLine("**************************************************");
                    foreach (var ganador in ganadores)
                    {
                        ganador.MostrarPersonaje();
                        Console.WriteLine("--------------------------------------------------");
                    }
                }else
                {
                    Console.WriteLine("No hay ganadores registrados en el historial.");
                }
                Console.ResetColor();
            }else
            {
                Console.WriteLine("No existe el historial de ganadores.");
            }

            Console.WriteLine("\nPresiona cualquier tecla para volver al menú principal...");
            Console.ReadKey();  // Espera a que el usuario presione una tecla
        }

    }



