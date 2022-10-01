using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentDateTime = DateTime.Now;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string title = @"
                                                                  
 ____  _____ _____    _____ __ __    _____ _____ _____ _____ _____ 
|    \|   __|  |  |  | __  |  |  |  |  _  |   | |_   _|  |  |     |
|  |  |   __|  |  |  | __ -|_   _|  |     | | | | | | |     |  |  |
|____/|_____|\___/   |_____| |_|    |__|__|_|___| |_| |__|__|_____|
                                                                   

version 0.0.1";
            Console.WriteLine(title);
            Thread.Sleep(2000);

            // input email
            Console.WriteLine("\nemail : ");
            var email_a = Console.ReadLine();

            // input first name
            Console.WriteLine("\nfirst name : ");
            var firstname_a = Console.ReadLine();

            // input last name
            Console.WriteLine("\nlast name : ");
            var lastname_a = Console.ReadLine();

            // input password
            Console.WriteLine("\npassword : ");
            var password_a = Console.ReadLine();


            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://europe-west3-asphaltgold-fdf14.cloudfunctions.net/asphaltgoldId-registerUser");
                var newPost = new Post()
                {
                    email = email_a,
                    firstName = firstname_a,
                    lastName = lastname_a,
                    password = password_a
                };
                Console.WriteLine($"\n[{currentDateTime}] - compte en cours de création...");
                Thread.Sleep(1000);
                var newPostJson = JsonConvert.SerializeObject(newPost);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"[{currentDateTime}] - finalisation du compte...");
                Thread.Sleep(1000);
                Console.WriteLine("\nCOMPTE :\n");
                Console.WriteLine(result);
                Thread.Sleep(1000);
            }
        }
    }
}
