namespace DashboardAPI.Data.Knowbe4
{
    [Fetch(24 * 60 * 60)]
    public class RiskScoreHistory : EndpointBase
    {

        [Column()]
        public double risk_score { get; set; }

        [Column()]
        public string date { get; set; } = "";


        public string FormattedDate 
        {
            get
            {
                // return date;
                return DateTime.Parse(date).ToString("MMMM yyyy");
            }
        }



        public async override Task<EndpointBase[]?> Fetch()
        {
            Providers.Knowbe4Provider kb4Provider = new Providers.Knowbe4Provider();
            return await kb4Provider.GetRiskScoreHistory();
        }






    }
}
