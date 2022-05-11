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



        [Column()]
        public int id { get; set; }

        [Column()]
        public string name { get; set; } = "";

        [Column()]
        public string group_type { get; set; } = "";

        [Column()]
        public string provisioning_guid { get; set; } = "";

        [Column()]
        public int member_count { get; set; }

        [Column()]
        public double current_risk_score { get; set; }

        [Column()]
        public string status { get; set; } = "";
    }
}
