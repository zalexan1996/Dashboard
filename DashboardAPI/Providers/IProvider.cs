namespace DashboardAPI.Providers
{
    public interface IProvider
    {
        void Connect();

        // Returns whether this provider has been authenticated.
        bool IsConnected { get; }

        // The mechanism for how this provider authenticates.
        Authentication.IAuthenticationMethod AuthenticationMethod { get; }
    }
}
