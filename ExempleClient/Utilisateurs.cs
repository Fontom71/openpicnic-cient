namespace ExempleClient
{
    public class Utilisateurs
    {
        private List<Utilisateur> _utilisateurs;

        public Utilisateurs()
        {
            this._utilisateurs = new List<Utilisateur>();
        }

        public void Add(Utilisateur utilisateur)
        {
            this._utilisateurs.Add(utilisateur);
        }
    }
}
