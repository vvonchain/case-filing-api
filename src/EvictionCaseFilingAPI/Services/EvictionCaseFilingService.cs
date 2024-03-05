using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EvictionCaseFilingAPI.Services
{
    public class EvictionCaseFilingService : IEvictionCaseFilingService
    {
        private readonly ILogger<EvictionCaseFilingService> _logger;

        public EvictionCaseFilingService(ILogger<EvictionCaseFilingService> logger)
        {
            _logger = logger;
        }

        public async Task<CreateCaseResponse> CreateNewCase(CreateCaseRequest request)
        {
            _logger.LogInformation("Creating a new case with request: {Request}", request);

            // Validate and process the request
            // Call external APIs or services as needed
            // Generate a unique order ID
            string orderId = Guid.NewGuid().ToString();

            var response = new CreateCaseResponse
            {
                OrderId = orderId,
                Message = "Case created successfully"
            };

            _logger.LogInformation("Case created successfully with order ID: {OrderId}", response.OrderId);
            return response;
        }

    }
}