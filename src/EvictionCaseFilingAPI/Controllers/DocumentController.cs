using EvictionCaseFilingAPI.Models;
using EvictionCaseFilingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EvictionCaseFilingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IEFilingService _eFilingService;

        public DocumentsController(IEFilingService eFilingService)
        {
            _eFilingService = eFilingService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument([FromBody] Document document)
        {
            var result = await _eFilingService.UploadDocumentAsync(document);
            return Ok(result);
        }
    }
}