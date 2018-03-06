using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HttpClientHandler hand = new HttpClientHandler();
            hand.AllowAutoRedirect = true;
            hand.UseDefaultCredentials = true;
            using (var client = new HttpClient(hand))
            {
                client.BaseAddress = new Uri(@"http://localhost:57791/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  This returns the JSON containing the current user name as expected. But the same thing fails from a UWP

                HttpResponseMessage response = client.GetAsync("api/values").Result;
                string name = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    name = response.Content.ReadAsStringAsync().Result;
                }
                Console.WriteLine(name);
                Console.ReadKey();
            }
        }
    }
}
