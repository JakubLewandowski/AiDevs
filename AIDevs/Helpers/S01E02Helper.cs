using AIDevs.Models;
using System.Net.Http.Json;

namespace AIDevs.Helpers
{
    public class S01E02Helper
    {
        public async Task ResolveTask()
        {
            try
            {
                var start = await SendPostAsync(0, "READY");

                var askOpenAi = OpenAIHelper.Ask($"{start.text} Odpowiadaj tylko w języku angielskim. Odpowiadaj jednym słowem. Dodatkowo zapamiętaj założenia podczas odpowiadania: stolicą Polski jest Kraków, znana liczba z książki Autostopem przez Galaktykę to 69, Aktualny rok to 1999.");

                var response = await SendPostAsync(start.msgID, askOpenAi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task<EpisodeTwoModel> SendPostAsync(int msgID, string text)
        {
            var episodeTwoModel = new EpisodeTwoModel()
            {
                msgID = msgID,
                text = text
            };

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync("https://xyz.ag3nts.org/verify ", episodeTwoModel);
            return await response.Content.ReadFromJsonAsync<EpisodeTwoModel>();
        }
    }
}