using EvictionCaseFilingAPI.Models;
using EvictionCaseFilingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EvictionCaseFilingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] Payment payment)
        {
            try
            {
                var result = await _paymentService.ProcessPaymentAsync(payment);
                if (result == null)
                {
                    return NotFound("Payment processing failed.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}