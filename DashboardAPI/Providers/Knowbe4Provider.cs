using System.Security;
using System.Net.Http;
using DashboardAPI.Data.Knowbe4;

namespace DashboardAPI.Providers
{
    public class Knowbe4Provider : IProvider
    {
        public Knowbe4Provider()
        {
            Connect();
        }
        public void Connect()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(System.Reflection.Assembly.GetCallingAssembly())
                .Build();

            _authenticationMethod.Token = configuration.GetValue<string>("KB4");
        }


        public string URL { get; } = "https://us.api.knowbe4.com/v1";

        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
        } private bool _isConnected = false;


        public Authentication.IAuthenticationMethod AuthenticationMethod
        {
            get
            {
                return _authenticationMethod;
            }
        } private Authentication.TokenAuthentication _authenticationMethod = new Authentication.TokenAuthentication();



        protected async Task<T?> Get<T>(string endpoint, string paramString = "")
        {
            
            try
            {
                HttpClient client = AuthenticationMethod.GetAuthenticatedClient($"{endpoint}{paramString}");
                
                if (client != null)
                {
                    // Perform the GET
                    HttpResponseMessage response = await client.GetAsync("");

                    // Return output converted from JSON
                    return (response.IsSuccessStatusCode) ? await response.Content.ReadFromJsonAsync<T>() : default(T);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception occured: {exception.Message}");
            }

            return default(T);
        }


        public async Task<PhishingSecurityTest[]?> GetPhishingSecurityTests(string paramString = "?per_page=500")
        {
            return await Get<PhishingSecurityTest[]>($"{URL}/phishing/security_tests", paramString);
        }



        public async Task<Group[]?> GetGroups(string paramString = "?per_page=500")
        {
            return await Get<Group[]>($"{URL}/groups", paramString);
        }

        public async Task<User[]?> GetUsers(string paramString = "?per_page=500")
        {
            return await Get<User[]>($"{URL}/users", paramString);
        }

        public async Task<RiskScoreHistory[]?> GetRiskScoreHistory(string paramString = "?per_page=500")
        {
            return await Get<RiskScoreHistory[]>($"{URL}/account/risk_score_history", paramString);
        }

        public async Task<Account?> GetAccountInfo(string paramString = "")
        {
            return await Get<Account>($"{URL}/account", paramString);
        }
        
    }
}
