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
    public static class ManejoApi
    {
        private static readonly HttpClient client = new HttpClient();

        private static readonly List<Spell> AuxSpells = new List<Spell>
        {
            new Spell { spell = "Expelliarmus", use = "Desarma al oponente", index = 1 },
            new Spell { spell = "Stupefy", use = "Aturde al oponente", index = 2 },
            new Spell { spell = "Expectro Patronum", use = "Genera una fuerza de energia positiva", index = 3 },
            new Spell { spell = "Avada Kedavra", use = "Causa la muerte del objetivo", index = 4 }

        };
        public static async Task<Spell> GetRandomSpellAsync()
        {
            var url = "https://potterapi-fedeperin.vercel.app/es/spells";
            try
            {
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
                    return ObtenerSpellRandom();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Problemas de acceso a la API");
                Console.WriteLine("Message :{0} ", e.Message);
                return ObtenerSpellRandom();
            }
        }

        private static Spell ObtenerSpellRandom()
        {
            Random random = new Random();
            int index = random.Next(AuxSpells.Count);
            return AuxSpells[index];
        }

    }
    
    
}
