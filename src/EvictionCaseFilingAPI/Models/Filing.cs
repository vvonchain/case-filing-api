using System.Xml.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("Filing")]
    public class Filing
    {
        [XmlElement("CourtID")]
        public string CourtID { get; set; }

        [XmlElement("CaseNumber")]
        public string CaseNumber { get; set; }

        [XmlElement("FilingType")]
        public string FilingType { get; set; }
    }
}