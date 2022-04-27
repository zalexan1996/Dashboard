using System.Security;
using System.Net.Http;

namespace DashboardAPI.Providers
{
    public class Knowbe4Provider : IProvider
    {
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
        } private bool _isConnected = false;

        public string Username
        {
            set
            {
                _username = value;
            }
        } private string? _username;

        public SecureString Password
        {
            set
            {
                _password = value;
            }
        } private SecureString? _password;



        public bool Connect(string username, SecureString password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }

            return false;
        }

        public bool Disconnect()
        {
            if (IsConnected)
            {
                return true;
            }
            return false;
        }

    }
}
