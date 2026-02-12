using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using RepoHub.Extensions;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RepoHub.Controllers
{
    [ApiController]
    [Route("/")]
    public class _404Controller(ILogger<_404Controller> logger) : ControllerBase
    {
        [Route("{**pathAndQuery}", Order = int.MaxValue)]
        [HttpGet, HttpPost, HttpDelete, HttpPut, HttpPatch]
        public async Task<IActionResult> _NotImplemented(string pathAndQuery)
        {
            var body = await Request.Body.ReadToEndAsync();

            logger.LogInformation($"[Url]: {Request.GetDisplayUrl()}");
            logger.LogInformation($"[Body]: {body}");
            return Content("_NotImplemented", "text/html", Encoding.UTF8);
        }
    }
}
