using System.Threading.Tasks;
using EvictionCaseFilingAPI.Models;

namespace EvictionCaseFilingAPI.Services
{
    public interface IEFilingService
    {
        Task NotifyFilingReviewComplete(NotifyFilingReviewCompleteRequest request);
        Task<GetFilingServiceResponse> GetFilingService(GetFilingServiceRequest request);
        Task<GetServiceInformationResponse> GetServiceInformation(GetServiceInformationRequest request);
        Task NotifyServiceComplete(NotifyServiceCompleteRequest request);
    }
}