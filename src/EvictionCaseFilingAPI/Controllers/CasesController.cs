using EvictionCaseFilingAPI.Models;
using EvictionCaseFilingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EvictionCaseFilingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly IEFilingService _eFilingService;

        public CasesController(IEFilingService eFilingService)
        {
            _eFilingService = eFilingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCase([FromBody] Envelope envelope)
        {
            var result = await _eFilingService.SubmitFilingAsync(envelope);
            return Ok(result);
        }
    }
}