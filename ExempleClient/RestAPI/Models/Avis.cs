namespace ExempleClient.RestAPI.Models
{
    public class Avis
    {
        public string IdUser { get; set; }
        public string IdLocalisation { get; set; }
        public string Titre { get; set; }
        public string Message { get; set; }
        public string DateAvis { get; set; }
        public int Note { get; set; }
    }
}
