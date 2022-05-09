namespace DashboardAPI.Data.Knowbe4
{
    [Fetch(24 * 60 * 60)]
    public class Group : EndpointBase
    {
        public async override Task<EndpointBase[]?> Fetch()
        {
            Console.WriteLine("Knowbe4 Groups Fetch!");
            Providers.Knowbe4Provider kb4Provider = new Providers.Knowbe4Provider();
            return await kb4Provider.GetGroups();
        }

        public override string[] ToStringArray()
        {
            return new string[]
            {
                name,
                member_count.ToString(),
                current_risk_score.ToString(),
                status
            };
        }


        [Column(ColumnType.Text, false)]
        public int id { get; set; }

        [Column(ColumnType.Text, true)]
        public string name { get; set; } = "";

        [Column(ColumnType.Text, false)]
        public string group_type { get; set; } = "";

        [Column(ColumnType.Text, false)]
        public string provisioning_guid { get; set; } = "";

        [Column(ColumnType.Text, true)]
        public int member_count { get; set; }

        [Column(ColumnType.Text, true)]
        public double current_risk_score { get; set; }

        [Column(ColumnType.Text, true)]
        public string status { get; set; } = "";
    }
}
