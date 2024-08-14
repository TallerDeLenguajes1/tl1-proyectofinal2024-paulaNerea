using System;
using System.IO;
using System.Text.Json;
using EspaciodePersonaje;

namespace EspacioHistorial
{
    public class HistorialJson
    {
        public static void GuardarGanador(Personaje ganador, string nombreArchivo)
        {
            List<Personaje> ganadores = new List<Personaje>();
            
            try
            {
                
                if (File.Exists(nombreArchivo))
                {
                    // Lee el contenido del archivo JSON
                    string existente = File.ReadAllText(nombreArchivo);

                    // Deserializa la cadena JSON a una lista de ganadores existente, si es nulll, devuelve lista vacia
                    ganadores = JsonSerializer.Deserialize<List<Personaje>>(existente) ?? new List<Personaje>();
                }

                ganadores.Add(ganador);

                string nuevo = JsonSerializer.Serialize(ganadores, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(nombreArchivo, nuevo);

                Console.WriteLine("Ganador agregado al historial exitosamente.");
                
            }
            catch (Exception ex)
            {
            
                Console.WriteLine($"Error al guardar el historial de ganadores: {ex.Message}");
            }
            

        }
        public static List<Personaje> LeerGanadores(string nombreArchivo)
        {
            
            try
            {
                string jsonString = File.ReadAllText(nombreArchivo);
                // Deserializa la cadena JSON a una lista de personajes
                //?? para proporcionar una lista vacía si Deserialize devuelve null
                return JsonSerializer.Deserialize<List<Personaje>>(jsonString) ?? new List<Personaje>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer ganadores: {ex.Message}");
                //lista vacia en caso de error
                return new List<Personaje>();
            }

        }

        public static bool Existe(string nombreArchivo)
        {
            // Verifica si el archivo existe y tiene datos
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
    }
    
}
