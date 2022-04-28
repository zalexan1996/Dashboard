namespace DashboardAPI.Data.Knowbe4
{

    public class ActiveCampaign : EndpointBase
    {
        [Column(ColumnType.Text, true)]
        public string Name { get; set; } = "";

        [Column(ColumnType.Text, true)]
        public int UserCount { get; set; }

        [Column(ColumnType.Percent, true)]
        public double PhishPercent { get; set; }

        [Column(ColumnType.ProgressBar, true)]
        public double Progress { get; set; }

        public override Task<EndpointBase[]?> Fetch()
        {
            throw new NotImplementedException();
        }

        public override string[] ToStringArray()
        {
            return new string[]
            {
                Name,
                UserCount.ToString(),
                PhishPercent.ToString(),
                $"{Progress}"
            };
        }

    }
}
