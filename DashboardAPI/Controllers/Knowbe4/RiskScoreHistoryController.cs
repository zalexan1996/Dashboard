using Microsoft.AspNetCore.Mvc;
using DashboardAPI.Data.Knowbe4;

namespace DashboardAPI.Controllers.Knowbe4
{
    [ApiController()]
    [Route("/knowbe4/risk_score_history")]
    public class RiskScoreHistoryController : Controller
    {
        [HttpGet(Name = "GetRiskScoreHistory")]
        public RiskScoreHistory[]? Get()
        {
            return Orchestrator.Instance.GetEndpointData<RiskScoreHistory>();
        }

        public static async Task<T[]?> Invoke<T>()
        {
            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri($"{DashboardAPI.Data.API_Info.URL}/knowbe4/risk_score_history")
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
