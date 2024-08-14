using System;
using EspacioFabrica;
using EspaciodePersonaje;
using EspacioHistorial;
using EspaciodePersonajeJson;

class Program
    {
        static void Main(string[] args)
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
                        NuevaPartida(archivoPersonajes);
                        break;

                    case 2:
                        Console.WriteLine("Mostrando Lista de Ganadores...");
                        MostrarGanadores(archivoGanadores);
                        break;

                    case 3:
                        continuar = false;
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
            Console.WriteLine("¡Bienvenido a 'Duelos en Hogwarts'!");
            Console.WriteLine("En este emocionante juego, tendrás la oportunidad de elegir a un mago y enfrentarlo a sus rivales.");
            Console.WriteLine("Demuestra tus habilidades en intensos combates por turnos. Cada turno, un mago atacará mientras que el otro se defenderá.");
            Console.WriteLine("El combate continuará hasta que uno de los magos pierda toda su salud. El perdedor será eliminado de la competencia.");
            Console.WriteLine("El mago victorioso recibirá mejoras en sus habilidades, como un aumento en la salud o en la defensa.");
            Console.WriteLine("¿Estás listo para probar tus habilidades y convertirte en el mejor mago de Hogwarts?");
            Console.WriteLine("¡Elige sabiamente y prepárate para la batalla!");
            Console.WriteLine("--------------------------------------------------");

        }
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("****************************************");
            Console.WriteLine("*              MENÚ PRINCIPAL           *");
            Console.WriteLine("****************************************");
            Console.WriteLine("* 1. Nueva Partida                      *");
            Console.WriteLine("* 2. Mostrar Ganadores                   *");
            Console.WriteLine("* 3. Salir                             *");
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
        
        static void NuevaPartida(string archivoPersonajes)
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
                for (int i = 0; i < 10; i++)
                {
                    // Crea un personaje usando la fábrica
                    Personaje personaje = FabricaPersonajes.CrearPersonaje();
                    // Agrega el personaje a la lista
                    personajes.Add(personaje);
                }

                PersonajesJson.GuardarPersonajes(personajes, archivoPersonajes);
                Console.WriteLine("Se crearon nuevos personajes y se guardaron en el archivo.");
            }

            MostrarPersonajesDisponibles(personajes);
            
        }

        static void MostrarPersonajesDisponibles(List<Personaje> personajes)
        {
            Console.WriteLine("Personajes disponibles: ");
            for (int i = 0; i < personajes.Count; i++)
            {
                // Mostrar el índice del personaje (i + 1 para que empiece en 1 en lugar de 0)
                Console.WriteLine($"[{i + 1}]");
                // Mostrar los detalles del personaje
                personajes[i].MostrarPersonaje();
            }
        }

        static void MostrarGanadores(string archivoGanadores)
        {

        }

    }



