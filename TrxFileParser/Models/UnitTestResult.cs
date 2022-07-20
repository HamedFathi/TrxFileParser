using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class UnitTestResult
    {
        [XmlAttribute("executionId")]
        public string Id { get; set; }

        [XmlAttribute("testId")]
        public string TestId { get; set; }

        [XmlAttribute("testListId")]
        public string TestListId { get; set; }

        [XmlAttribute("testName")]
        public string TestName { get; set; }

        [XmlAttribute("computerName")]
        public string ComputerName { get; set; }

        [XmlAttribute("duration")]
        public string Duration { get; set; }

        [XmlAttribute("startTime")]
        public string StartTime { get; set; }

        [XmlAttribute("endTime")]
        public string EndTime { get; set; }

        [XmlAttribute("testType")]
        public string TestTypeId { get; set; }

        [XmlAttribute("relativeResultsDirectory")]
        public string RelativeResultsDirectoryId { get; set; }

        [XmlAttribute("outcome")]
        public string Outcome { get; set; }

        [XmlElement("output")]
        public Output Output { get; set; }
    }
}
