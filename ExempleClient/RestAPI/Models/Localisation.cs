namespace ExempleClient.RestAPI.Models
{
    public class Localisation
    {
        public int IdLocalisation { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Note { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
