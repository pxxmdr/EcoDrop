using Microsoft.AspNetCore.Mvc;
using EcoDrop.PublicApi.Services;
using System.Threading.Tasks;

namespace EcoDrop.PublicApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalDataController : ControllerBase
    {
        private readonly ExternalApiService _externalApiService;

        public ExternalDataController(ExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetExternalPosts()
        {
            var data = await _externalApiService.GetExternalDataAsync();
            return Ok(data);
        }
    }
}
