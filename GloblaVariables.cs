using System.Net.Http.Headers;

namespace ShopManagementMVCConsume
{
    public class GloblaVariables
    {
        public static async Task<HttpResponseMessage> GetResponseAsync(string str)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("https://localhost:44355/api/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var getClient = await Client.GetAsync(str, CancellationToken.None);

            return getClient;
        }

        public static async Task<HttpResponseMessage> PostResponseAsync<T>(string str, T model)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("https://localhost:44355/api/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var getClient = await Client.PostAsJsonAsync(str, model);

            return getClient;
        }
    }
}
