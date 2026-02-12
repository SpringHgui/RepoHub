using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RepoHub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        // http://192.168.2.125:5089/repository/nuget.org-proxy/index.json
        [Route("/{repoName}/{**pathQuery}")]
        public async Task<IActionResult> Get(string repoName, string pathQuery)
        {
            using var httpClient = new HttpClient();
            var res = await httpClient.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri($"https://api.nuget.org/v3/index.json"),
                Method = new HttpMethod(Request.Method)
            });

            var content = await res.Content.ReadAsStringAsync();
            return Content(content);
        }
    }
}
