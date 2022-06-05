using System.Net.Http.Headers;

namespace ShopManagementMVCConsume
{
    public class GloblaVariables
    {
        private static string baseURL = "https://khvshopapi.azurewebsites.net/api/";
        public static async Task<HttpResponseMessage> GetResponseAsync(string str)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(baseURL);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var getClient = await Client.GetAsync(str, CancellationToken.None);

            return getClient;
        }

        public static async Task<HttpResponseMessage> GetResponseAsyncID(string str, int id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(baseURL);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var getClient = await Client.GetAsync(str + "/" + id.ToString(), CancellationToken.None);

            return getClient;
        }

        public static async Task<HttpResponseMessage> PostResponseAsync<T>(string str, T model)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(baseURL);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var getClient = await Client.PostAsJsonAsync(str, model);

            return getClient;
        }

        public static async Task<HttpResponseMessage> PutResponseAsync<T>(string str, int id, T model)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(baseURL);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var getClient = await Client.PutAsJsonAsync(str + "/" + id, model);

            return getClient;
        }

        public static async Task<HttpResponseMessage> DeleteResponseAsync(string str, int id)
        {
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri(baseURL);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var getClient = await Client.DeleteAsync(str + "/" + id.ToString());

            return getClient;
        }
    }
}
