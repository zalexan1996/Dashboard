namespace DashboardAPI.Data
{
    public abstract class EndpointBase
    {
    
        public static ColumnInfo GetColumnInfo(Type t, string columnName)
        {
            // Get the property information for the supplied property
            var property = t.GetProperties().Where(p => p.Name == columnName).First();

            // Complain if the conversion failed.
            if (property == null)
            {
                throw new Exception($"Couldn't find column with name '{columnName}' in type '{t.Name}'");
            }

            // Get the Column Attribute for this property
            ColumnAttribute? columnAttribute = property
                    .GetCustomAttributes(true)
                    .Where(a => (a as ColumnAttribute) != null).First() as ColumnAttribute;

            // Complain if the conversion failed.
            if (columnAttribute == null)
            {
                throw new Exception($"Tried to make ColumnInfo from invalid column with name '{columnName}' in type '{t.Name}'");
            }

            // Construct a ColumnInfo from this column.
            return new ColumnInfo()
            {
                Name = columnName,
                Type = columnAttribute != null ? columnAttribute.ColumnType : ColumnType.Text
            };
        }

        public static List<ColumnInfo> ColumnInfosFromType(Type t)
        {
            List<ColumnInfo> output = new List<ColumnInfo>();
            
            // Create a ColumnInfo for each property
            foreach (var prop in t.GetProperties())
            {
                var columnAttributes = prop.GetCustomAttributes(true).Where(a => (a as ColumnAttribute) != null);
                if (columnAttributes.Count() == 0)
                {
                    return output;
                }

                ColumnAttribute? columnAttribute = columnAttributes.First() as ColumnAttribute;

                if (columnAttribute != null)
                {
                    output.Add(new ColumnInfo()
                    {
                        Name = prop.Name,
                        Type = columnAttribute != null ? columnAttribute.ColumnType : ColumnType.Text
                    });
                }
            }

            return output;
        }

        public static List<ColumnInfo> GetColumnInfos(Type t, string[] columns)
        {
            return columns.Select(c => GetColumnInfo(t, c)).ToList();
        }

        public string[]? ToStringArray(string[] columns)
        {
            return columns.Select(c => GetType().GetProperty(c).GetValue(this).ToString()).ToArray();
        }

        public abstract Task<EndpointBase[]?> Fetch();


    }
}
