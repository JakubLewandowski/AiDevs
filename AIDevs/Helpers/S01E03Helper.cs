using AIDevs.Models;
using System.Net.Http.Json;

namespace AIDevs.Helpers
{
    public class S01E03Helper
    {
        public async Task ResolveTask()
        {
            try
            {
                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync($"https://centrala.ag3nts.org/data/{Environment.GetEnvironmentVariable("AI_DEVS_API_KEY")}/json.txt");
                response.EnsureSuccessStatusCode();
                var jsonToRepair = await response.Content.ReadFromJsonAsync<EpisodeThreeModel>();
                jsonToRepair.apikey = Environment.GetEnvironmentVariable("AI_DEVS_API_KEY");

                foreach (var data in jsonToRepair.testData)
                {
                    var split = data.question.Split(" + ");
                    var a = Convert.ToInt16(split[0]);
                    var b = Convert.ToInt16(split[1]);
                    data.answer = a + b;
                }

                var questionsForOpenAi = jsonToRepair.testData.Where(x => x.test != null).ToList();

                foreach (var question in questionsForOpenAi)
                {
                    question.test.a = OpenAIHelper.Ask($"{question.test.q} Answer in one word.");
                }

                var answer = new EpisodeThreeAnswerModel() { answer = jsonToRepair };

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