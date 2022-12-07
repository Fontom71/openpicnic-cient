namespace ExempleClient
{
    public class Utilisateur
    {
        public Utilisateur(string pseudo, string nom, string prenom, string password, string email, int isAdmin = 0, int idAvatar = 0)
        {
            this.pseudo = pseudo;
            this.nom = nom;
            this.prenom = prenom;
            this.password = password;
            this.email = email;
            this.isAdmin = isAdmin;
            this.idAvatar = idAvatar;
        }

        public int idUser;
        public string pseudo;
        public string nom;
        public string prenom;
        public string password;
        public string email;
        public int isAdmin;
        public int idAvatar;
    }
}
