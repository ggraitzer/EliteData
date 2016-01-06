using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using EliteData.ConsoleApplication.Models;
using Newtonsoft.Json;

namespace EliteData.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Systems...");
            var result = Task.Run(() => GetSystems()).Result;
            Console.WriteLine("Content Received:");
            var systems = result.Where(m => m.population != null && m.population != 0).OrderBy(m => m.population).Reverse().Take(20).ToList();
            foreach (var s in systems)
            {
                Console.WriteLine($"Name: {s.Name} Population: {s.population}");
            }
            Console.ReadKey();
        }

        private static async Task<IEnumerable<SolarSystem>> GetSystems()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://eddb.io/archive/v4/systems.json");
            var content = await response.Content.ReadAsStringAsync();
            IEnumerable<SolarSystem> systemList = JsonConvert.DeserializeObject<IEnumerable<SolarSystem>>(content);

            return systemList;
        }
    }
}
