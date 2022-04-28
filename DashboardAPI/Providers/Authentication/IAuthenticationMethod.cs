using System.Net.Http;
namespace DashboardAPI.Providers.Authentication
{
    public interface IAuthenticationMethod
    {
        HttpClient GetAuthenticatedClient(string authUrl);
    }
}
