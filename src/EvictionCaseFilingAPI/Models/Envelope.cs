using System.Xml.Serialization;
using System.Collections.Generic;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("Envelope")]
    public class Envelope
    {
        [XmlElement("Filing")]
        public Filing Filing { get; set; }

        [XmlArray("Documents")]
        [XmlArrayItem("Document")]
        public List<Document> Documents { get; set; } = new List<Document>();

        [XmlElement("User")]
        public User User { get; set; }

        [XmlElement("Attorney")]
        public Attorney Attorney { get; set; }

        [XmlArray("ServiceContacts")]
        [XmlArrayItem("ServiceContact")]
        public List<ServiceContact> ServiceContacts { get; set; } = new List<ServiceContact>();

        [XmlArray("CaseParties")]
        [XmlArrayItem("CaseParty")]
        public List<CaseParty> CaseParties { get; set; } = new List<CaseParty>();

        [XmlArray("CasePartyAttorneys")]
        [XmlArrayItem("CasePartyAttorney")]
        public List<CasePartyAttorney> CasePartyAttorneys { get; set; } = new List<CasePartyAttorney>();
    }
}