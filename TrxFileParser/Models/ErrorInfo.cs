using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class ErrorInfo
    {
        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("stackTrace")]
        public string StackTrace { get; set; }
    }
}
