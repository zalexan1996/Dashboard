namespace Dashboard.Data.Table
{
    public class ColumnInfo
    {
        public enum ColumnType
        {
            Text, ProgressBar
        }

        public string Name { get; set; } = "";
        public ColumnType Type { get; set; } = ColumnType.Text;

    }

    public class Table
    {


        public string? Header { get; set; }

        public List<ColumnInfo> ColumnInfo = new List<ColumnInfo>();

        public List<string[]> Data = new List<string[]>();






        public void AddColumn(ColumnInfo info) { ColumnInfo.Add(info); }
        public void AddRow(string[] row) { Data.Add(row); }

    }
}
