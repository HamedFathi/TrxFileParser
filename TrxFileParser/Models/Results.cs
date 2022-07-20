using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrxFileParser.Models
{
    public class Results
    {
        [XmlElement("unitTestResult")]
        public List<UnitTestResult> UnitTestResults { get; set; }
    }
}
