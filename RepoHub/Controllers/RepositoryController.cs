using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using RepoHub.Extensions;
using System.Threading.Tasks;

namespace RepoHub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepositoryController(ILogger<RepositoryController> logger) : ControllerBase
    {
        // http://192.168.2.125:5089/repository/nuget.org-proxy/index.json
        [Route("{repoName}/{**pathQuery}")]
        public async Task<IActionResult> Get(string repoName, string pathQuery)
        {
            var body = await Request.Body.ReadToEndAsync();

            logger.LogInformation($"===== [1Url]: {Request.Method} {Request.GetDisplayUrl()}");
            logger.LogInformation($"===== [1Body]: {body}");

            if (pathQuery == "index.json")
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

            return Ok();
        }
    }
}
