using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class Output
    {
        [XmlElement("stdOut")]
        public string StdOut { get; set; }

        [XmlElement("stdErr")]
        public string StdErr { get; set; }

        [XmlElement("errorInfo")]
        public ErrorInfo ErrorInfo { get; set; }
    }
}
