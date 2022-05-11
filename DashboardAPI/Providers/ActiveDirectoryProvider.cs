using DashboardAPI.Providers.Authentication;
using DashboardAPI.Data.ActiveDirectory;

using System.DirectoryServices;

namespace DashboardAPI.Providers
{
	public class ActiveDirectoryProvider : IProvider
	{
		protected static IConfigurationRoot builder = new ConfigurationBuilder()
			.AddUserSecrets(System.Reflection.Assembly.GetCallingAssembly())
			.Build();

		protected T? GetPropertyValue<T>(SearchResult searchResult, string propertyName)
		{
			if (searchResult.Properties[propertyName].Count > 0)
			{
				return (T)searchResult.Properties[propertyName][0];
			}
			return default(T);
		}
		protected T[]? GetPropertyArrayValue<T>(SearchResult searchResult, string propertyName)
		{
			List<T> output = new List<T>();
			if (searchResult != null && searchResult.Properties.Contains(propertyName))
			{
				for (int i = 0; i < searchResult.Properties[propertyName].Count; i++)
                {
					output.Add((T)searchResult.Properties[propertyName][i]);
				}
			}
			return output.ToArray();
		}

		public static string DomainController
		{
			get
			{
				return builder.GetValue<string>("DomainController");
			}
		}
		public static string DomainConnectionString
		{
			get
			{
				return builder.GetValue<string>("DomainConnectionString");
			}
		}
		public static string DomainSearchBase
		{
			get
			{
				return builder.GetValue<string>("DomainSearchBase");
			}
		}
		public static string LockedOutUserSearchBase
		{
			get
			{
				return builder.GetValue<string>("LockedOutUserSearchBase");
			}
		}
		public static string RASUserGroupName
		{
			get
			{
				return builder.GetValue<string>("RASUserGroupName");
			}
		}

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


		public async Task<ADUser[]?> GetUsers()
		{
			return await Task.Run(() =>
			{
				List<ADUser> output = new List<ADUser>();
				DirectoryEntry de = new DirectoryEntry(DomainConnectionString);
				DirectorySearcher ds = new DirectorySearcher(de);
				ds.Filter = "(&(objectCategory=User)(objectClass=person))";
				ds.SearchRoot = new DirectoryEntry(DomainSearchBase);

				ds.PropertiesToLoad.Add("name");
				ds.PropertiesToLoad.Add("lockoutTime");
				ds.PropertiesToLoad.Add("memberOf");
				ds.PropertiesToLoad.Add("distinguishedName");



				SearchResultCollection results = ds.FindAll();
				foreach (SearchResult sr in results)
				{
					output.Add(new ADUser
					{
						Name = GetPropertyValue<string>(sr, "name"),
						LockoutTime = GetPropertyValue<long>(sr, "lockoutTime"),
						MemberOf = GetPropertyArrayValue<string>(sr, "memberOf"),
						DistinguishedName = GetPropertyValue<string>(sr, "distinguishedName")
					});

				}
				return output.ToArray();
			});
		}
	}
}
