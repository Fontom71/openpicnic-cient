using Newtonsoft.Json;
using System.Text;

namespace ExempleClient.RestAPI
{
    public class API
    {
        private static HttpClient client = new HttpClient();

        // POST method generic
        public static async Task<T> PostAsync<T>(string uri, T item)
        {
            AuthentificationAPI();
            string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string content2 = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content2);
            }

            return default(T);
        }

        // GET method generic
        public static async Task<T> GetAsync<T>(string uri)
        {
            AuthentificationAPI();
            T items = default(T);

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<T>(content);
            }

            return items;
        }

        // GET method generic
        public static async Task<T> GetAsync<T>(string uri, string id)
        {
            AuthentificationAPI();
            T items = default(T);

            HttpResponseMessage response = await client.GetAsync(uri + id);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<T>(content);
            }

            return items;
        }

        // PUT method generic
        public static async Task<T> PutAsync<T>(string uri, T item)
        {
            AuthentificationAPI();
            string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string content2 = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content2);
            }

            return default(T);
        }

        // DELETE method generic
        public static async Task DeleteAsync(string uri, string id)
        {
            AuthentificationAPI();
            await client.DeleteAsync(uri + id);
        }

        // DELETE method generic
        public static async Task DeleteAsync(string uri)
        {
            AuthentificationAPI();
            await client.DeleteAsync(uri);
        }

        private static void AuthentificationAPI()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("API_KEY") + ":" + Environment.GetEnvironmentVariable("API_SECRET")); //Création d'un tableau de byte contenant l'API_KEY et l'API_SECRET
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}
