using AIDevs.Models;
using System.Net.Http.Json;

namespace AIDevs.Helpers
{
    public class PoligonHelper
    {
        public async Task DowloadAndResend()
        {
            var jsonToSend = new CentralaReportModel<List<string>>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://poligon.aidevs.pl/dane.txt");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var split = responseBody.Remove(responseBody.Length - 1).Split('\n').ToList();
                jsonToSend = new CentralaReportModel<List<string>>()
                {
                    task = "POLIGON",
                    apikey = Environment.GetEnvironmentVariable("AI_DEVS_API_KEY"),
                    answer = split
                };
            }

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("https://poligon.aidevs.pl/verify", jsonToSend);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
        }
    }
}