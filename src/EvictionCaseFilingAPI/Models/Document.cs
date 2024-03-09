using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    public class Document
    {
        [Key]
        [JsonPropertyName("documentId")]
        public string DocumentID { get; set; }

        [Required]
        [JsonPropertyName("documentType")]
        public string DocumentType { get; set; }

        [Required]
        [JsonPropertyName("documentData")]
        public byte[] DocumentData { get; set; }
    }
}