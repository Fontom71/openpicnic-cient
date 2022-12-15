using ExempleClient.RestAPI;
using ExempleClient.RestAPI.Models;

DotNetEnv.Env.Load();
List<Utilisateur> users = await API.GetAsync<List<Utilisateur>>("https://fontom.myftp.org/api/users");

foreach (Utilisateur user in users)
{
    Console.WriteLine(user.Nom + " " + user.Prenom + " " + user.Email + " " + user.Password + " " + user.IsAdmin + " " + user.IdAvatar);
}