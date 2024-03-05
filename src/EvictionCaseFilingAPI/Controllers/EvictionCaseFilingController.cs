using System.Threading.Tasks;
using EvictionCaseFilingAPI.Models;
using EvictionCaseFilingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvictionCaseFilingAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class EvictionCaseFilingController : ControllerBase
    {
        private readonly IEvictionCaseFilingService _service;

        public EvictionCaseFilingController(IEvictionCaseFilingService service)
        {
            _service = service;
        }

        [HttpPost("/cases/new")]
        public async Task<IActionResult> CreateNewCase([FromBody] CreateCaseRequest request)
        {
            var response = await _service.CreateNewCase(request);
            return Ok(response);
        }

    }
}