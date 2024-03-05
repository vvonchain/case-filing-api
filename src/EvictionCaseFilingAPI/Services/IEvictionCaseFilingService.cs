using System.Threading.Tasks;
using EvictionCaseFilingAPI.Models;

namespace EvictionCaseFilingAPI.Services
{
    public interface IEvictionCaseFilingService
    {
        Task<CreateCaseResponse> CreateNewCase(CreateCaseRequest request);
    }
}