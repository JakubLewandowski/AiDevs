using AIDevs.Models;
using System.Net.Http.Json;

namespace AIDevs.Helpers
{
    public class CentralaReportHelper
    {
        public async Task<string> SendAnswer<T>(T answer, string task) where T : class
        {
            var taskResponse = string.Empty;

            try
            {
                var answerJson = new CentralaReportModel<T>()
                {
                    task = task,
                    apikey = Environment.GetEnvironmentVariable("AI_DEVS_API_KEY"),
                    answer = answer
                };

                using HttpClient client = new();
                HttpResponseMessage response = await client.PostAsJsonAsync("https://centrala.ag3nts.org/report", answerJson);

                if (response.IsSuccessStatusCode)
                {
                    taskResponse = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    taskResponse = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                taskResponse = ex.ToString();
            }

            return taskResponse;
        }
    }
}