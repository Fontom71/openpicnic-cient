using ExempleClient;
using Newtonsoft.Json;
using System.Collections;
using System.Text;

DotNetEnv.Env.Load();
HttpClient client = new HttpClient();      //Client Http communiquant avec l'API
var byteArray = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("API_KEY") + ":" + Environment.GetEnvironmentVariable("API_SECRET")); //Création d'un tableau de byte contenant l'API_KEY et l'API_SECRET
client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
Utilisateur user = new Utilisateur("Pseudo", "Nom", "Prenom", "Password", "Email"); //Création d'un utilisateur
Load("https://fontom.myftp.org/api/users/");
//Save(user);
//Delete(4);

//Méthode pour charger un utilisateur
async void Load(string url)
{
    // Récupère une liste d'utilisateurs depuis l'API et les affiche dans la console
    var request = new HttpRequestMessage(HttpMethod.Get, url);
    var response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();
    // si la réponse est un tableau, on le convertit en liste d'utilisateurs
    if (response[0] == '[')
    {
        List<Utilisateur> users = JsonConvert.DeserializeObject<List<Utilisateur>>(response);
        foreach (Utilisateur user in users)
        {
            Console.WriteLine(user.idUser + " " + user.pseudo + " " + user.nom + " " + user.prenom + " " + user.password + " " + user.email + " " + user.isAdmin + " " + user.idAvatar);
        }
    }
    else
    {
        // sinon on convertit la réponse en utilisateur
        Utilisateur user = JsonConvert.DeserializeObject<Utilisateur>(response);
        Console.WriteLine(user.idUser + " " + user.pseudo + " " + user.nom + " " + user.prenom + " " + user.password + " " + user.email + " " + user.isAdmin + " " + user.idAvatar);
    }
}

// utilisateur sera remplacé par IData
async void Save(string url, Utilisateur user)
{
    //On crée une personne à envoyer à l'API
    Utilisateur nouvellePersonne = user;
    //On affiche la personne au
    string jsonString = JsonConvert.SerializeObject(nouvellePersonne);
    //On crée un contenu à envoyer à l'API
    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
    //On envoie la requête à l'API
    var reponseHttp2 = await client.PostAsync(url, content).Result.Content.ReadAsStringAsync();
    Console.WriteLine(reponseHttp2);
}

// supprime l'utilisateur avec l'id
async void Delete(string url, int id)
{
    String adresseEnvoi = String.Format("{0}{1}", url, id);
    var reponseHttp2 = await client.DeleteAsync(adresseEnvoi).Result.Content.ReadAsStringAsync();
    Console.WriteLine(reponseHttp2);
}