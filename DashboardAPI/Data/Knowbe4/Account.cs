namespace DashboardAPI.Data.Knowbe4
{
    [Fetch(24 * 60 * 60)]
    public class Account : EndpointBase
    {
        public class Admin
		{
            public int Id { get; set; }
            public string FirstName { get; set; } = "";
            public string LastName { get; set; } = "";
            public string Email { get; set; } = "";

            public User? UserData { get; set; }

            [Column(ColumnType.Text, true)]
            public string DisplayName
			{
                get
				{
                    return $"{FirstName} {LastName}";
				}
			}

            [Column(ColumnType.Text, true)]
            public string? JoinedOn
			{
                get
                {
                    return UserData?.joined_on;
                }
			}

            public Admin()
            {
                // User[]? Users = DashboardAPI.Controllers.Orchestrator.Instance.GetEndpointData<User>();
                // UserData = Users?.Where(e => e.id == Id).First();
            }
		}

        public async override Task<EndpointBase[]?> Fetch()
        {
            Providers.Knowbe4Provider kb4Provider = new Providers.Knowbe4Provider();
            Account? accountInfo = await kb4Provider.GetAccountInfo();

            return new Account[] { accountInfo };
        }

        public override string[] ToStringArray()
        {
            return new string[]
            {
                name,
                number_of_seats.ToString(),
                current_risk_score.ToString()
            };
        }


        [Column(ColumnType.Text, true)]
        public string name { get; set; } = "";

        [Column(ColumnType.Text, false)]
        public string type { get; set; } = "";

        [Column(ColumnType.Text, false)]
        public string[] domains { get; set; } = new string[] { };

        [Column(ColumnType.Text, false)]
        public Admin[] admins { get; set; } = new Admin[] { };

        [Column(ColumnType.Text, false)]
        public string subscription_level { get; set; } = "";

        [Column(ColumnType.Text, false)]
        public string subscription_end_date { get; set; } = "";

        [Column(ColumnType.Text, true)]
        public int number_of_seats { get; set; }

        [Column(ColumnType.Percent, true)]
        public double current_risk_score { get; set; }


    }
}
