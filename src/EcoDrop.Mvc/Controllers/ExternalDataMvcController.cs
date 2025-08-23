using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EcoDrop.Mvc.Controllers
{
    public class ExternalDataMvcController : Controller
    {
        private readonly HttpClient _httpClient;

        public ExternalDataMvcController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("http://localhost:5242/api/ExternalData/posts");

            if (!response.IsSuccessStatusCode)
                return View(new List<dynamic>());

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<dynamic>>(content);

            return View(data);
        }
    }
}
