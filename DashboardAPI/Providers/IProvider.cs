namespace DashboardAPI.Providers
{
    public interface IProvider
    {
        public bool Connect(string username, System.Security.SecureString password);
        public bool Disconnect();





        public bool IsConnected { get; }
        public string Username { set; }
        public System.Security.SecureString Password { set; } 
    }
}
