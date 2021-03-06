using DashboardAPI.Controllers;

namespace DashboardAPI.Data.Knowbe4
{ 
    // Fetch once every 24 hours
    [Fetch(24 * 60 * 60)]
    public class PhishingSecurityTest : EndpointBase
    {
        public async override Task<EndpointBase[]?> Fetch()
        {
            Providers.Knowbe4Provider kb4Provider = new Providers.Knowbe4Provider();
            return await kb4Provider.GetPhishingSecurityTests();
        }


        [Column]
        public int campaign_id { get; set; }

        [Column]
        public int pst_id { get; set; }

        [Column()]
        public string name { get; set; } = "";

        [Column()]
        public string status { get; set; } = "";

        [Column]
        public object[]? groups { get; set; } = null;

        [Column(ColumnType.Percent)]
        public double phish_prone_percentage
        {
            get
            {
                // Do a conversion for the table.
                return _phish_prone_percentage * 10;
            }
            set
            {
                _phish_prone_percentage = value;
            }
        } private double _phish_prone_percentage;

        [Column]
        public string started_at { get; set; } = "";

        [Column]
        public int duration { get; set; }

        [Column]
        public object[]? categories { get; set; }

        [Column]
        public object? template { get; set; }

        [Column]
        public object? landing_page { get; set; }

        [Column]
        public int scheduled_count { get; set; }

        [Column]
        public int delivered_count { get; set; }

        [Column]
        public int opened_count { get; set; }

        [Column]
        public int clicked_count { get; set; }

        [Column]
        public int replied_count { get; set; }

        [Column]
        public int attachment_open_count { get; set; }

        [Column]
        public int macro_enabled_count { get; set; }

        [Column]
        public int data_entered_count { get; set; }

        [Column]
        public int reported_count { get; set; }

        [Column]
        public int bounced_count { get; set; }

        [Column(ColumnType.ProgressBar)]
        public double progress
        {
            get
            {
                return scheduled_count == 0 ? 0 : ((double)delivered_count / (double)scheduled_count) * 100;
            }
        }





    }
}
