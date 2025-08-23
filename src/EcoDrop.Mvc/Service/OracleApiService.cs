using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EcoDrop.Mvc.Service
{
    public class OracleApiService
    {
        private readonly HttpClient _httpClient;

        public OracleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5175");
        }

        public async Task<List<RecyclingPointDto>> GetRecyclingPointsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<RecyclingPointDto>>("/api/RecyclingPoints");
            return response ?? new List<RecyclingPointDto>();
        }
    }

    public class RecyclingPointDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
