namespace DashboardAPI.Data
{
    public class EndpointBase
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

                output.Add(new ColumnInfo()
                {
                    Name = prop.Name,
                    Type = columnAttribute != null ? columnAttribute.ColumnType : ColumnType.Text
                });
            }

            return output;
        }


        public virtual string[] ToStringArray()
        {
            throw new NotImplementedException();
        }
    }
}
