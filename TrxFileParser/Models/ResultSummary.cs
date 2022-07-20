using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class ResultSummary
    {
        [XmlAttribute("outcome")]
        public string Outcome { get; set; }

        [XmlElement("counters")]
        public Counters Counters { get; set; }
    }
}
