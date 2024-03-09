using EvictionCaseFilingAPI.Models;
using EvictionCaseFilingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var result = await _eFilingService.SubmitFilingAsync(envelope);
                if (result == null)
                {
                    return NotFound("The filing submission did not return any result.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return StatusCode(500, $"An error occurred while submitting the filing: {ex.Message}");
            }
        }
    }
}