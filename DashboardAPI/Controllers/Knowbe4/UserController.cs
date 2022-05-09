using Microsoft.AspNetCore.Mvc;
using DashboardAPI.Data.Knowbe4;

namespace DashboardAPI.Controllers.Knowbe4
{
    [ApiController()]
    [Route("/knowbe4/users")]
    public class UserController : Controller
    {
        [HttpGet(Name = "GetUsers")]
        public User[]? Get()
        {
            return Orchestrator.Instance.GetEndpointData<User>();
        }

        public static async Task<T[]?> Invoke<T>()
        {
            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri($"{DashboardAPI.Data.API_Info.URL}/knowbe4/users")
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
