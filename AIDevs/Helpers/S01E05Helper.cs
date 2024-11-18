using AIDevs.Models;
using System.Net.Http.Json;

namespace AIDevs.Helpers
{
    public class S01E05Helper
    {
        public async Task ResolveTask()
        {
            try
            {
                var url = $"https://centrala.ag3nts.org/data/{Environment.GetEnvironmentVariable("AI_DEVS_API_KEY")}/cenzura.txt";
                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string text = await response.Content.ReadAsStringAsync();

                var askAi = OpenAIHelper.Ask($"Zamień wszelkie wrażliwe dane (imię + nazwisko, nazwę ulicy + numer, miasto, wiek osoby na słowo CENZURA. Tekt do obróbki:  {text}");

                var answer = new CentralaReportModel<string>()
                {
                    task = "CENZURA",
                    apikey = Environment.GetEnvironmentVariable("AI_DEVS_API_KEY"),
                    answer = askAi
                };
                using HttpClient client2 = new HttpClient();
                HttpResponseMessage response2 = await client2.PostAsJsonAsync("https://centrala.ag3nts.org/report", answer);

                if (response2.IsSuccessStatusCode)
                {
                    string responseBody = await response2.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Error: {response2.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}