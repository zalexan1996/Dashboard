namespace DashboardAPI.Data.Knowbe4
{
    public class TrainingEnrollment : EndpointBase
    {
        public override string[] ToStringArray()
        {
            return new string[]
            {

            };
        }

        public override Task<EndpointBase[]?> Fetch()
        {
            throw new NotImplementedException();
        }

        [Column(ColumnType.Text, true)]
        public string Name
        { 
            get
            {
                return $"{user.first_name} {user.last_name}";
            }
        }

        [Column(ColumnType.Text, true)]
        public string Campaign
        {
            get
            {
                return campaign_name;
            }
        }
        [Column(ColumnType.Text, true)]
        public string Status
        {
            get
            {
                return status;
            }
        }


        public class User
        {
            public int id { get; set; }
            public string first_name { get; set; } = "";
            public string last_name { get; set; } = "";
            public string email { get; set; } = "";
        }


        public int enrollment_id { get; set; }
        public string content_type { get; set; } = "";
        public string module_name { get; set; } = "";
        public User user { get; set; } = new User();
        public string campaign_name { get; set; } = "";
        public string enrollment_date { get; set; } = "";
        public string start_date { get; set; } = "";
        public string completion_date { get; set; } = "";
        public string status { get; set; } = "";
        public int time_spent { get; set; }
        public bool policy_acknowledged { get; set; }


    }
}
