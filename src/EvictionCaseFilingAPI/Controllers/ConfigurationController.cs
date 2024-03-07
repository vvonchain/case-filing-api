using EvictionCaseFilingAPI.Services;
using Microsoft.AspNetCore.Mvc;
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
            var policy = await _configurationService.GetPolicyAsync();
            return Ok(policy);
        }
    }
}