using DashboardAPI.Data;

namespace DashboardAPI.Helpers
{
    public class HttpHelper
    {

        public static HttpResponseMessage? Get(HttpClient client)
        {
            try
            {
                // Send the request
                HttpResponseMessage response = client.GetAsync("").Result;
                return response.IsSuccessStatusCode ? response : null;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception occured: {exception.Message}");
            }
            return null;
        }



        public static async Task<T[]?> Get<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                // Create the HTTP client
                client.BaseAddress = new Uri($"{API_Info.URL}{endpoint}");
                client.DefaultRequestHeaders.Add("accept", "application/json");

                return await Get<T>(client);
            }
        }

        public static async Task<T[]?> Get<T>(HttpClient client)
        {
            // Send the HTTP GET
            HttpResponseMessage? response = Get(client);

            // Return the converted output if there is any.
            return response == null ? null : await response.Content.ReadFromJsonAsync<T[]?>();
        }


    }
}
