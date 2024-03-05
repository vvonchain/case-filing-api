using EvictionCaseFilingAPI.Models;
using EvictionCaseFilingAPI.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace EvictionCaseFilingAPI.Tests
{
    public class EvictionCaseFilingServiceTests
    {
        private readonly Mock<ILogger<EvictionCaseFilingService>> _loggerMock;
        private readonly EvictionCaseFilingService _service;

        public EvictionCaseFilingServiceTests()
        {
            _loggerMock = new Mock<ILogger<EvictionCaseFilingService>>();
            _service = new EvictionCaseFilingService(_loggerMock.Object);
        }

        [Fact]
        public async void CreateNewCase_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var request = new CreateCaseRequest
            {
                Location = "County Name",
                Category = "Civil-Real Property",
                CaseType = "Eviction",
                // ... other properties
            };

            // Act
            var response = await _service.CreateNewCase(request);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.OrderId);
            Assert.Equal("Case created successfully", response.Message);
        }

    }
}