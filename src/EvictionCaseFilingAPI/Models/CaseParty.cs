using System.Xml.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("CaseParty")]
    public class CaseParty
    {
        [XmlElement("CasePartyID")]
        public string CasePartyID { get; set; }

        [XmlElement("PartyType")]
        public string PartyType { get; set; }
    }
}