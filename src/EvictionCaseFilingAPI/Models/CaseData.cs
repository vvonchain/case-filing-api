using System.Xml.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("CaseData")]
    public class CaseDataSchema
    {
        [XmlElement("CaseNumber")]
        public string CaseNumber { get; set; }

        [XmlElement("PlaintiffName")]
        public string PlaintiffName { get; set; }

        [XmlElement("DefendantName")]
        public string DefendantName { get; set; }

        // Add more properties as per your XML schema
    }
}