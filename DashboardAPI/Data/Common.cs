namespace DashboardAPI.Data
{
    public enum ColumnType
    {
        Text, ProgressBar, Percent
    }

    public class ColumnInfo
    {

        public string Name { get; set; } = "";
        public ColumnType Type { get; set; } = ColumnType.Text;

    }

    // Data for defining how a specific column should be interpreted
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(ColumnType columnType = ColumnType.Text)
        {
            ColumnType = columnType;
        }


        public ColumnType ColumnType { get; set; }
    }

    public class API_Info
    {
        public static string URL = "https://localhost:7999";
    }
}
