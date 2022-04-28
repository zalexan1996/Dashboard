using System.Security;
using System.Net.Http;

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
            _authenticationMethod.Token = File.ReadAllText("kb4.token");
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





        public async Task<Data.Knowbe4.PhishingSecurityTest[]?> GetPhishingSecurityTests()
        {
            try
            {
                HttpClient client = AuthenticationMethod.GetAuthenticatedClient($"{URL}/phishing/security_tests");

                if (client != null)
                {
                    return await Helpers.HttpHelper.Get<Data.Knowbe4.PhishingSecurityTest>(client);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception occured: {exception.Message}");
            }

            return null;
        }
    }
}
