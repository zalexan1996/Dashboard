using Microsoft.AspNetCore.Mvc;
using DashboardAPI.Data.ActiveDirectory;
using System.DirectoryServices;

namespace DashboardAPI.Controllers.ActiveDirectory
{
    [ApiController()]
    [Route("/activeDirectory/users")]
    public class UserController : Controller
    {
        [HttpGet(Name = "GetADUsers")]
        public ADUser[]? Get()
        {
            return Orchestrator.Instance.GetEndpointData<ADUser>();
        }

        public static async Task<T[]?> Invoke<T>()
		{

            try
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri($"{DashboardAPI.Data.API_Info.URL}/activeDirectory/users")
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
