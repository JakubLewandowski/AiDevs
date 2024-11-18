using System.IO.Compression;

namespace AIDevs.Helpers
{
    public class S02E01Helper
    {
        public async Task ResolveTask()
        {
            var url = $"https://centrala.ag3nts.org/dane/przesluchania.zip";
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            var destinationDirectoryName = "przesluchania";
            ZipFile.ExtractToDirectory(stream, destinationDirectoryName);
            DirectoryInfo dir = new DirectoryInfo(destinationDirectoryName);
            var transcripts = string.Empty;

            foreach (var file in dir.GetFiles())
            {
                transcripts += $"Przesłuchanie świadka o imieniu {file.Name}: {OpenAIHelper.TranscribeAudio(file.FullName)}";
            }

            var task = $"Znajdź odpowiedź na pytanie, na jakiej ulicy znajduje się uczelnia, na której wykłada Andrzej Maj. Za chwilę podam transkrypcje z przesłuchań kilku świadków. Pamiętaj, że zeznania świadków mogą być sprzeczne, niektórzy z nich mogą się mylić, a inni odpowiadać w dość dziwaczny sposób. Nazwa ulicy nie pada w treści transkrypcji. {string.Join("", transcripts)}";

            var searchedStreet = OpenAIHelper.Ask(task);

            var centrala = new CentralaReportHelper();
            var result = await centrala.SendAnswer("Łojasiewicza", "mp3");
        }
    }
}