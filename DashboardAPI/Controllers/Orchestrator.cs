using System.Reflection;
using DashboardAPI.Data;

namespace DashboardAPI.Controllers
{
    public class Orchestrator
    {
        protected Orchestrator()
        {
            // Get all EndpointBase that have a FetchAttribute
            List<Type> endpointTypes = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(type => type.GetCustomAttributes<FetchAttribute>().Count() == 1)
                .ToList();

            // Add the endpoint data to our maps
            foreach (Type endpoint in endpointTypes)
            {
                EndpointFetchMap.Add(DateTime.Now, endpoint);
                EndpointData.Add(endpoint, null);
            }

            // Run the timer once a second.
            FetchTimer = new Timer(FetchCallback, null, 1, 1000);
        }


        protected async void FetchCallback(object? state)
        {
            Console.WriteLine("Checking!");
            // While we have expired entries
            while (EndpointFetchMap.Keys.First() < DateTime.Now)
            {
                DateTime expiredDate = EndpointFetchMap.Keys.First();

                // Get the type of the current endpoint
                Type endpointType = EndpointFetchMap[expiredDate];
                if (endpointType == null) return;

                // Try to get the Fetch data for the endpoint
                FetchAttribute? fetchAttribute = endpointType.GetCustomAttribute<FetchAttribute>();
                if (fetchAttribute == null) return;

                // Create a new endpoint object. We'll use it to call the Fetch function.
                object? endpoint = Activator.CreateInstance(endpointType);
                if (endpoint == null || endpoint as EndpointBase == null) return;


                // Remove the first entry.
                EndpointFetchMap.Remove(expiredDate);

                // Add the new entry
                DateTime newDateTime = DateTime.Now.AddSeconds(fetchAttribute.RefreshInterval);
                EndpointFetchMap.Add(newDateTime, endpointType);

                // Get the new data
                var newData = await ((EndpointBase)endpoint).Fetch();
                EndpointData[endpointType] = newData;


            }
        }

        public T[]? GetEndpointData<T>() where T : EndpointBase
        {
            if (EndpointData.ContainsKey(typeof(T)))
            {
                return EndpointData[typeof(T)] as T[];
            }
            return null;
        }

        // The singleton instance.
        public static Orchestrator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Orchestrator();
                }
                return _instance;
            }
        } private static Orchestrator? _instance;


        // Will get all controller data instances and fetch the latest if it's time to do so
        protected Timer FetchTimer { get; set; }

        // 1. The next DateTime that we need to fetch the endpoint data.
        // 2. The type of the endpoint that needs to be fetched
        protected SortedDictionary<DateTime, Type> EndpointFetchMap = new SortedDictionary<DateTime, Type>();

        // 1. The type of the endpoint
        // 2. The data of the endpoint
        protected Dictionary<Type, EndpointBase[]?> EndpointData = new Dictionary<Type, EndpointBase[]?>();
    }
}
