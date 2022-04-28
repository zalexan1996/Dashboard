namespace DashboardAPI.Data
{
    public abstract class EndpointBase
    {
        public static List<ColumnInfo> ColumnInfosFromType(Type t)
        {
            List<ColumnInfo> output = new List<ColumnInfo>();
            
            // Create a ColumnInfo for each property
            foreach (var prop in t.GetProperties())
            {
                ColumnAttribute? columnAttribute = prop.GetCustomAttributes(true)
                    .Where(a => (a as ColumnAttribute) != null)
                    .First() as ColumnAttribute;

                if (columnAttribute != null && columnAttribute.Visibility)
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

        public abstract string[] ToStringArray();

        public abstract Task<EndpointBase[]?> Fetch();


    }
}
