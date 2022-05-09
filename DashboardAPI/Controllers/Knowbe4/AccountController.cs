using Microsoft.AspNetCore.Mvc;
using DashboardAPI.Data.Knowbe4;

namespace DashboardAPI.Controllers.Knowbe4
{
    [ApiController()]
    [Route("/knowbe4/account")]
    public class AccountController : Controller
    {
        [HttpGet(Name = "GetAccountInformation")]
        public Account[]? Get()
        {
            return Orchestrator.Instance.GetEndpointData<Account>();
        }

        public static async Task<T[]?> Invoke<T>()
        {
            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri($"{DashboardAPI.Data.API_Info.URL}/knowbe4/account")
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
