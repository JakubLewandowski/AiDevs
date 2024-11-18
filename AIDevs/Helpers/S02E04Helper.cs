using AIDevs.Models;
using System.IO.Compression;

namespace AIDevs.Helpers
{
    public class S02E04Helper
    {
        public async Task ResolveTask()
        {

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://centrala.ag3nts.org/dane/pliki_z_fabryki.zip");
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();

            var destinationDirectoryName = "S02E04";
            ZipFile.ExtractToDirectory(stream, destinationDirectoryName);

            DirectoryInfo dir = new(destinationDirectoryName);
            foreach (var file in dir.GetFiles())
            {

            }

            var answer = new S02E04Model();
            {

            };

            var centrala = new CentralaReportHelper();
            var result = await centrala.SendAnswer(answer, "kategorie");
        }
    }
}