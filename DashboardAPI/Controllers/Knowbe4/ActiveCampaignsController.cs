using Microsoft.AspNetCore.Mvc;
using DashboardAPI.Data.Knowbe4;

namespace DashboardAPI.Controllers.Knowbe4
{
    [ApiController]
    [Route("knowbe4/active_campaigns")]
    public class ActiveCampaignsController : Controller
    {

        [HttpGet(Name = "GetKnowbe4Campaigns")]
        public IEnumerable<ActiveCampaign> Get()
        {
            return Enumerable.Range(1, 7).Select(index => new ActiveCampaign
            {
                Name = $"Campaign{index}",
                PhishPercent = Math.Round(Random.Shared.NextDouble(), 2) * 100,
                Progress = Math.Round(Random.Shared.NextDouble(), 2) * 100,
                UserCount = Random.Shared.Next(30, 120)
            }).ToArray();
        }
    }
}
