namespace DashboardAPI.Providers.Authentication
{
    public class TokenAuthentication : IAuthenticationMethod
    {
        public string? Token { get; set; }



        public HttpClient GetAuthenticatedClient(string authUrl)
        {

            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(authUrl)
            };

            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");



            return client;
        }

    }
}
