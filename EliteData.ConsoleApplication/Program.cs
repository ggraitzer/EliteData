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
            Console.Write("For systems press 1, for stations press 2: ");
            var key = Console.ReadKey();
            Console.WriteLine();

            Runner runner = new Runner();
            if (key.KeyChar == '1')
            {
                runner.Systems();
            }
            else if (key.KeyChar == '2')
            {
                Console.Write("Max Attempts: ");
                string input = Console.ReadLine();
                int attempts = int.Parse(input);

                runner.Stations(attempts);
            }

            Console.ReadKey();
        }
    }

    internal class Runner
    {
        EliteRepository repo = new EliteRepository();

        public void Systems()
        {
            Console.WriteLine("Getting Systems...");
            var result = Task.Run(() => repo.GetSystemsAsync()).Result;
            Console.WriteLine("Content Received:");
            var systems = result.Where(m => m.population != null && m.population != 0).OrderBy(m => m.population).Reverse().Take(20).ToList();
            foreach (var s in systems)
            {
                Console.WriteLine($"Name: {s.Name} Population: {s.population}");
            }
        }

        public void Stations(int maxTries)
        {
            Console.WriteLine("Getting Stations...");
            int attempt = 0;
            bool successful = false;

            while (attempt < maxTries && !successful)
            {
                try
                {
                    var result = Task.Run(() => repo.GetStationsAsync()).Result;
                    successful = true;
                    Console.WriteLine("Content Received:");
                    var stations = result.Where(m => m.has_shipyard != null && m.has_shipyard != 0).OrderBy(m => m.system_id).Reverse().Take(20).ToList();
                    foreach (var s in stations)
                    {
                        Console.WriteLine($"Name: {s.name} Ships for sale: {string.Concat(s.selling_ships)}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Attempt {attempt + 1} failed, exception: {e.ToString()}");
                    if (e.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {e.InnerException.ToString()}");
                    }
                }
            }


            Console.ReadKey();
        }
    }
}
