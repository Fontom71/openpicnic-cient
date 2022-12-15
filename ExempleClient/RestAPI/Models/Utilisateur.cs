namespace ExempleClient.RestAPI.Models
{
    public class Utilisateur
    {
        public int IdUser { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IsAdmin { get; set; }
        public int IdAvatar { get; set; }
    }
}
