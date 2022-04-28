namespace DashboardAPI.Data
{
    public class FetchAttribute : Attribute
    {
        public FetchAttribute(int refreshInterval)
        {
            RefreshInterval = refreshInterval;
        }

        // How often the controller will fetch its underlying data.
        public int RefreshInterval { get; set; }
    }
}
