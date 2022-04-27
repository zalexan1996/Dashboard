namespace DashboardAPI.Data
{
    public class Table
    {
        public string? Header { get; set; }

        public List<ColumnInfo> ColumnInfo = new List<ColumnInfo>();

        public List<string[]> Data = new List<string[]>();


        public void AddColumn(ColumnInfo info) { ColumnInfo.Add(info); }
        public void AddRow(string[] row) { Data.Add(row); }



        public static async Task<Table?> GetTable<T>(string endpoint)
        {
            // Fetch the data from the endpoint as an array of our supplied types. 
            var objects = await Helpers.HttpHelper.Get<T>(endpoint);

            // Exit prematurely if there was no data retrieved from the endpoint
            if (objects == null) return null;

            // Get the column information for our table.
            Table output = new Table()
            {
                ColumnInfo = EndpointBase.ColumnInfosFromType(typeof(T))
            };

            // Add a table row for each object
            foreach (T? obj in objects ?? Enumerable.Empty<T>())
            {
                EndpointBase? endpointObj = obj as EndpointBase;
                if (endpointObj != null)
                {
                    output.AddRow(endpointObj.ToStringArray());
                }
            }

            return output;
        }
    }
}
