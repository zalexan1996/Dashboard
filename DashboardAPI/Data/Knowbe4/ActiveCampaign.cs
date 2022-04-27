namespace DashboardAPI.Data.Knowbe4
{
    public class ActiveCampaign : EndpointBase
    {
        [Column()]
        public string Name { get; set; } = "";

        [Column()]
        public int UserCount { get; set; }

        [Column(ColumnType.Percent)]
        public double PhishPercent { get; set; }

        [Column(ColumnType.ProgressBar)]
        public double Progress { get; set; }


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
