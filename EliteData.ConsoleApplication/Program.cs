using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using EliteData.DataRepository.Models;
using Newtonsoft.Json;
using EliteData.DataRepository;

namespace EliteData.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var instance = new Runner();
            instance.Run();
        }
    }

    internal class Runner
    {
        EliteRepository repo = new EliteRepository();

        public void Run()
        {
            Console.WriteLine("Getting Systems...");
            var result = Task.Run(() => repo.GetSystemsAsync()).Result;
            Console.WriteLine("Content Received:");
            var systems = result.Where(m => m.population != null && m.population != 0).OrderBy(m => m.population).Reverse().Take(20).ToList();
            foreach (var s in systems)
            {
                Console.WriteLine($"Name: {s.Name} Population: {s.population}");
            }
            Console.ReadKey();
        }
    }
}
