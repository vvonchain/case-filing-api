using EvictionCaseFilingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EvictionCaseFilingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet("policy")]
        public async Task<IActionResult> GetPolicy()
        {
            try
            {
                var policy = await _configurationService.GetPolicyAsync();
                if (policy == null)
                {
                    return NotFound("Policy not found.");
                }
                return Ok(policy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}