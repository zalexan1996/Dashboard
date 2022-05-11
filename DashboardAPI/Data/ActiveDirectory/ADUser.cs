using DashboardAPI.Providers;

namespace DashboardAPI.Data.ActiveDirectory
{
    [Fetch(60)]
    public class ADUser : EndpointBase
    {

        public bool IsMemberOf(string group, bool wildcard)
        {
            return wildcard ? MemberOf.Any(e=>e.Contains(group)) : MemberOf.Contains(group);
        }
        public bool IsInOU(string ou)
        {
            return String.IsNullOrEmpty(DistinguishedName) ? false : DistinguishedName.Contains(ou);
        }

        [Column()]
        public string? Name { get; set; } = "";

        [Column()]
        public long LockoutTime { get; set; } = 0;

        [Column()]
        public string[] MemberOf { get; set; } = new string[] { };

        [Column()]
        public string? DistinguishedName { get; set; } = "";





        [Column()]
        public bool IsLockedOut
        {
            get
            {
                return LockoutTime > 0;
            }
        }

        [Column()]
        public string LockedOutSince
        {
            get
            {
                return IsLockedOut ? DateTime.FromFileTimeUtc(LockoutTime).ToString("g") : "Not Locked out";
            }
        }



        public async override Task<EndpointBase[]?> Fetch()
        {
            Console.WriteLine("ADUsers Fetched");
            ActiveDirectoryProvider adProvider = new ActiveDirectoryProvider();
            return await adProvider.GetUsers();
        }

    }
}
