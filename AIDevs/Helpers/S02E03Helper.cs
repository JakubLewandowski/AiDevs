using AIDevs.Models;
using System.Net.Http.Json;

namespace AIDevs.Helpers
{
    public class S02E03Helper
    {
        public async Task ResolveTask()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://centrala.ag3nts.org/data/{Environment.GetEnvironmentVariable("AI_DEVS_API_KEY")}/robotid.json");
            response.EnsureSuccessStatusCode();
            var task = await response.Content.ReadFromJsonAsync<S02E02TaskModel>();

            var imageUrl = OpenAIHelper.Draw($"Utwórz obraz: {task?.description}. Grafika musi być w formacie PNG i mieć wymiary 1024×1024 px.");

            var centrala = new CentralaReportHelper();
            var result = await centrala.SendAnswer(imageUrl, "robotid");
        }
    }
}