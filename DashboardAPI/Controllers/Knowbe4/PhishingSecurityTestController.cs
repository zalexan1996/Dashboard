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

        public static async Task<T[]?> Invoke<T>()
        {
            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri($"{DashboardAPI.Data.API_Info.URL}/knowbe4/phishing_security_tests")
                };

                var Result = client.GetAsync("").Result;
                return Result.IsSuccessStatusCode ? await Result.Content.ReadFromJsonAsync<T[]?>() : null;
            }
            catch
            {
                Console.WriteLine("Invocation Failed.");
            }
            return null;
        }
    }
}
