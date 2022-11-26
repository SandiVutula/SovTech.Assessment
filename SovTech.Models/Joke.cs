namespace SovTech.Models
{
    public class Joke
    {
        public string Id { get; set; }
        public string[] Categories { get; set; }
        public string Url { get; set; }
        public string Icon_Url { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string Value { get; set; }
    }
}