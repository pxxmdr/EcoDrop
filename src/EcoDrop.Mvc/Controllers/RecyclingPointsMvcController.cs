using Microsoft.AspNetCore.Mvc;
using EcoDrop.Mvc.Service;
using System.Threading.Tasks;

namespace EcoDrop.Mvc.Controllers
{
    public class RecyclingPointsMvcController : Controller
    {
        private readonly OracleApiService _oracleApiService;

        public RecyclingPointsMvcController(OracleApiService oracleApiService)
        {
            _oracleApiService = oracleApiService;
        }

        public async Task<IActionResult> Index()
        {
            var recyclingPoints = await _oracleApiService.GetRecyclingPointsAsync();
            return View(recyclingPoints);
        }
    }
}
