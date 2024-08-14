using System.Text.Json;
namespace EspacioManejoApi
{
    public class ManejoApi
    {
        public static async Task<string?> GetDatosAsync()
        {
            var url = "https://potterapi-fedeperin.vercel.app/es/characters";
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                //la api me devuelve un lista, la deserealizo
                List<DatoHechizoApi> hechizosApi  = JsonSerializer.Deserialize<List<DatoHechizoApi>>(responseBody) ?? new List<DatoHechizoApi>();


                if (hechizosApi == null || hechizosApi.Count == 0)
                {
                    Console.WriteLine("No se encontraron hechizos.");
                    return null; // Puede ser nulo si no se encuentran hechizos
                }

                // Selecciono un hechizo random de la lista
                Random rand = new Random();
                int randomIndex = rand.Next(hechizosApi .Count);
                string hechizoSeleccionado = hechizosApi[randomIndex].Name;
                return hechizoSeleccionado;
            }    
            catch (HttpRequestException e)
            {
                Console.WriteLine("Problemas de acceso a la API");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

    }
    
    public class DatoHechizoApi
    {
        public string Name { get; set; } = string.Empty;
    }
}
