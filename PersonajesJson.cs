using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using EspaciodePersonaje;

public class PersonajesJson
{
    public static void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
    {
        try
        {
            // Serializa la lista de personajes a una cadena JSON
            string jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });
            // Guarda la cadena JSON en un archivo
            File.WriteAllText(nombreArchivo, jsonString);
            Console.WriteLine($"Personajes guardados en {nombreArchivo}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar personajes: {ex.Message}");
        }
    }
    
    public List<Personaje> LeerPersonajes(string nombreArchivo)
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
            Console.WriteLine($"Error al leer personajes: {ex.Message}");
            //lista vacia en caso de error
            return new List<Personaje>();
        }
    }

    public bool Existe(string nombreArchivo)
    {
        return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;   

    }


}