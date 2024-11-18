using System.Text.Json.Serialization;

namespace AIDevs.Models
{
    public class EpisodeThreeModel
    {
        public string apikey { get; set; }
        public string description { get; set; }
        public string copyright { get; set; }
        [JsonPropertyName("test-data")]
        public List<EpisodeThreeTestDataModel> testData { get; set; }
    }

    public class EpisodeThreeTestDataModel
    {
        public string question { get; set; }
        public int answer { get; set; }
        public EpisodeThreeTestModel test { get; set; }
    }

    public class EpisodeThreeTestModel
    {
        public string q { get; set; }
        public string a { get; set; }
    }

    public class EpisodeThreeAnswerModel
    {
        public string task { get; set; } = "JSON";
        public string apikey { get; set; } = Environment.GetEnvironmentVariable("AI_DEVS_API_KEY");
        public EpisodeThreeModel answer { get; set; }
    }
}