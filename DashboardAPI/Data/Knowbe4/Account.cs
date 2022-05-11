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

            [Column()]
            public string DisplayName
			{
                get
				{
                    return $"{FirstName} {LastName}";
				}
			}

            [Column()]
            public string? JoinedOn
			{
                get
                {
                    return UserData?.joined_on;
                }
			}

		}

        public async override Task<EndpointBase[]?> Fetch()
        {
            Providers.Knowbe4Provider kb4Provider = new Providers.Knowbe4Provider();
            Account? accountInfo = await kb4Provider.GetAccountInfo();

            return new Account[] { accountInfo };
        }


        [Column()]
        public string name { get; set; } = "";

        [Column()]
        public string type { get; set; } = "";

        [Column()]
        public string[] domains { get; set; } = new string[] { };

        [Column()]
        public Admin[] admins { get; set; } = new Admin[] { };

        [Column()]
        public string subscription_level { get; set; } = "";

        [Column()]
        public string subscription_end_date { get; set; } = "";

        [Column()]
        public int number_of_seats { get; set; }

        [Column(ColumnType.Percent)]
        public double current_risk_score { get; set; }


    }
}
