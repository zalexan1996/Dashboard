using DashboardAPI.Providers.Authentication;

namespace DashboardAPI.Providers
{
	public class ExchangeProvider : IProvider
	{
		public bool IsConnected
		{
			get
			{
				return _isConnected;
			}
		}
		private bool _isConnected = false;


		public IAuthenticationMethod AuthenticationMethod
		{
			get
			{
				return _authenticationMethod;
			}
		}
		private TokenAuthentication _authenticationMethod = new TokenAuthentication();

		public void Connect()
		{
			throw new NotImplementedException();
		}


		public void Test()
		{
		
		}
	}
}
