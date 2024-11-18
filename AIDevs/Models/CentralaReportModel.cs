namespace AIDevs.Models
{
    public class CentralaReportModel<T> where T : class
    {
        public string task { get; set; }
        public string apikey { get; set; }
        public T answer { get; set; }
    }
}