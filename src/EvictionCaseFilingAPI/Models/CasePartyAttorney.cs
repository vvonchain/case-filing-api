using System.Xml.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("CasePartyAttorney")]
    public class CasePartyAttorney
    {
        [XmlElement("CasePartyID")]
        public string CasePartyID { get; set; }

        [XmlElement("AttorneyID")]
        public string AttorneyID { get; set; }
    }
}