using System.Net.Http;
using System.Threading.Tasks;

namespace EcoDrop.PublicApi.Services
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetExternalDataAsync()
        {
            
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
