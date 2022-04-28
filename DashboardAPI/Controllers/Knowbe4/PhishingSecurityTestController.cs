using Microsoft.AspNetCore.Mvc;
using DashboardAPI.Data.Knowbe4;

namespace DashboardAPI.Controllers.Knowbe4
{
    [ApiController()]
    [Route("/knowbe4/phishing_security_tests")]
    public class PhishingSecurityTestController : Controller
    {
        [HttpGet(Name = "GetPhishingSecurityTests")]
        public PhishingSecurityTest[]? Get()
        {
            return Orchestrator.Instance.GetEndpointData<PhishingSecurityTest>();
        }
    }
}
