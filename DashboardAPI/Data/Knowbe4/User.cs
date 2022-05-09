namespace DashboardAPI.Data.Knowbe4
{
    [Fetch(24 * 60 * 60)]
    public class User : EndpointBase
    {
        public async override Task<EndpointBase[]?> Fetch()
        {
            Console.WriteLine("Knowbe4 Users Fetch!");
            Providers.Knowbe4Provider kb4Provider = new Providers.Knowbe4Provider();
            return await kb4Provider.GetUsers();
        }

        public override string[] ToStringArray()
        {
            return new string[]
            {
                DisplayName,
                phish_prone_percentage.ToString(),
                current_risk_score.ToString()
            };
        }

        [Column(ColumnType.Text, true)]
        public string DisplayName
        {
            get
            {
                return $"{first_name} {last_name}";
            }
        }

        [Column]
        public int id { get; set; }
        [Column]
        public string employee_number { get; set; } = "";
        [Column]
        public string first_name { get; set; } = "";
        [Column]
        public string last_name { get; set; } = "";
        [Column]
        public string job_title { get; set; } = "";
        [Column]
        public string email { get; set; } = "";

        [Column(ColumnType.Percent, true)]
        public double phish_prone_percentage { get; set; }
        [Column]
        public string phone_number { get; set; } = "";
        [Column]
        public string extension { get; set; } = "";
        [Column]
        public string mobile_phone_number { get; set; } = "";
        [Column]
        public string location { get; set; } = "";
        [Column]
        public string division { get; set; } = "";
        [Column]
        public string manager_name { get; set; } = "";
        [Column]
        public string manager_email { get; set; } = "";
        [Column]
        public bool provisioning_managed { get; set; }
        [Column]
        public string provisioning_guid { get; set; } = "";
        [Column]
        public object[]? groups { get; set; }

        [Column(ColumnType.Text, true)]
        public double current_risk_score { get; set; }
        [Column]
        public string[] aliases { get; set; } = { };
        [Column]
        public string joined_on { get; set; } = "";
        [Column]
        public string last_sign_in { get; set; } = "";
        [Column]
        public string status { get; set; } = "";
        [Column]
        public string organization { get; set; } = "";
        [Column]
        public string department { get; set; } = "";
        [Column]
        public string language { get; set; } = "";
        [Column]
        public string comment { get; set; } = "";
        [Column]
        public string employee_start_date { get; set; } = "";
        [Column]
        public string archived_at { get; set; } = "";
        [Column]
        public string custom_field_1 { get; set; } = "";
        [Column]
        public string custom_field_2 { get; set; } = "";
        [Column]
        public string custom_field_3 { get; set; } = "";
        [Column]
        public string custom_field_4 { get; set; } = "";
        [Column]
        public string custom_date_1 { get; set; } = "";
        [Column]
        public string custom_date_2 { get; set; } = "";

    }
}
