namespace EvictionCaseFilingAPI.Models
{
    public class CreateCaseRequest
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string CaseType { get; set; }
    }
}