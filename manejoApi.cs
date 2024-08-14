using System.Text.Json;
using System.Text.Json.Serialization;
namespace EspacioManejoApi
{
    public class Spell
    {
        [JsonPropertyName("spell")]
        public string spell { get; set; }

        [JsonPropertyName("use")]
        public string use { get; set; }

        [JsonPropertyName("index")]
        public int index { get; set; }
    }
    public class ManejoApi
    {
        static async Task<Spell> GetRandomSpellAsync()
        {
            var url = "https://potterapi-fedeperin.vercel.app/es/spells";
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                
                List<Spell> spells = JsonSerializer.Deserialize<List<Spell>>(responseBody);

                if (spells != null && spells.Count > 0)
                {
                    Random random = new Random();
                    int index = random.Next(spells.Count);
                    return spells[index];
                }
                else
                {
                    Console.WriteLine("No se encontraron hechizos en la respuesta.");
                    return null;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Problemas de acceso a la API");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

    }
    
    
}
