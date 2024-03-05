using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace EvictionCaseFilingAPI.Services
{
    [ServiceContract]
    public interface IEvictionCaseFilingService
    {
        [OperationContract]
        Task<CreateCaseResponse> CreateNewCase(CreateCaseRequest request);

        [OperationContract]
        Task<UploadDocumentResponse> UploadComplaintDocument(string caseId, Stream fileContent);

    }
}