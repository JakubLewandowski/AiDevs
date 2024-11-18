using System.Text.RegularExpressions;

namespace AIDevs.Helpers
{
    public class S01E01Helper
    {
        public async Task ResolveTask()
        {
            try
            {
                var question = string.Empty;
                var url = "https://xyz.ag3nts.org/";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Regex regex = new Regex("<p id=\"human-question\">Question:<br \\/>(.*)<\\/p>");

                    Match match = regex.Match(responseBody);

                    question = match.Groups[1].Value;
                }

                var answer = OpenAIHelper.Ask($"{question} Podaj tylko rok.");

                var values = new Dictionary<string, string>
                {
                    { "username", "tester" },
                    { "password", "574e112a" },
                    { "answer", answer }
                };

                var content = new FormUrlEncodedContent(values);

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);

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
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
            }
        }
    }
}