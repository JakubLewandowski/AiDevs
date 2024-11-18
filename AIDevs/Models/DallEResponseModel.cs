namespace AIDevs.Models
{
    public class DallEResponseModel
    {
        public string created { get; set; }
        public List<DallEResponseDataModel> data { get; set; }
    }

    public class DallEResponseDataModel
    {
        public string revised_prompt { get; set; }
        public string url { get; set; }
    }
}
