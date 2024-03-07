using System.Xml.Serialization;

namespace EvictionCaseFilingAPI.Models
{
    [XmlRoot("Envelope")]
    public class Envelope
    {
        [XmlElement("Filing")]
        public Filing Filing { get; set; }

        [XmlElement("Document")]
        public Document Document { get; set; }

        [XmlElement("User")]
        public User User { get; set; }

        [XmlElement("Attorney")]
        public Attorney Attorney { get; set; }

        [XmlElement("ServiceContact")]
        public ServiceContact ServiceContact { get; set; }

        [XmlElement("CaseParty")]
        public CaseParty CaseParty { get; set; }

        [XmlElement("CasePartyAttorney")]
        public CasePartyAttorney CasePartyAttorney { get; set; }
    }
}