namespace Challenge.Models
{
    public class JDoodleOptions
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Language { get; set; }
        public int VersionIndex { get; set; }

        public string ExecuteEndpoint { get; set; }
    }
}