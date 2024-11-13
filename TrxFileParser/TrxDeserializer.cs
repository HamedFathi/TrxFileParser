using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using TrxFileParser.Models;

namespace TrxFileParser
{
    public static class TrxDeserializer
    {
        public static TestRun Deserialize(string filePath)
        {
            var rgx = new Regex("xmlns=\".*?\" ?");
            var fileContent = rgx.Replace(File.ReadAllText(filePath), string.Empty);
            return DeserializeContent(fileContent);
        }

        public static TestRun DeserializeContent(string fileContent)
        {
            var xmlNamespaceRegex = new Regex("xmlns=\".*?\" ?");
            var contentWithoutNamespace = xmlNamespaceRegex.Replace(fileContent, string.Empty);
            var xs = new XmlSerializer(typeof(TestRun));
            using (var reader = new StringReader(contentWithoutNamespace))
            {
                var testRun = (TestRun)xs.Deserialize(reader);
                return testRun;
            }
        }

        public static string ToMarkdown(this TestRun testRun, Header header = Header.H2)
        {
            var sb = new StringBuilder();
            var groups = testRun.Results.UnitTestResults
                .GroupBy(x => x.TestId)
                .ToList();
            var h = new string('#', (int)header);
            foreach (var group in groups)
            {
                var testName = @group.FirstOrDefault()?.TestName;
                var name = testName?.Substring(0, testName.IndexOf('('));
                sb.AppendLine($"{h} {name}");
                var i = 0;
                foreach (var g in @group.OrderBy(x => x.StartTime))
                {
                    if (testName == null) continue;
                    var text = g.TestName.Substring(testName.IndexOf(')') + 1).Trim();
                    sb.AppendLine($"{++i}. {text}");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
