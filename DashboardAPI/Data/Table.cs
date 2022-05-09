using System.Linq;

namespace DashboardAPI.Data
{
    public class Table
    {
        public string? Header { get; set; }

        public List<ColumnInfo> ColumnInfo = new List<ColumnInfo>();

        public List<string[]> Data = new List<string[]>();



        public void AddColumn(ColumnInfo info) { ColumnInfo.Add(info); }
        public void AddRow(string[] row) { Data.Add(row); }


        protected bool GetAll<T>(T type)
        {
            return true;
        }

        public static Table GetTable<T>(T[] data)
        {

            // Get the column information for our table.
            Table output = new Table()
            {
                ColumnInfo = EndpointBase.ColumnInfosFromType(typeof(T))
            };


            // Add a table row for each object
            foreach (T? obj in data ?? Enumerable.Empty<T>())
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
