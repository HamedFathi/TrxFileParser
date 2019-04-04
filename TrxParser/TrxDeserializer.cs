using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;
using TrxFileParser.Models;

namespace TrxFileParser
{
    /// <summary>
    /// Deserializes trx files
    /// </summary>
    public static class TrxConvert
    {
        /// <summary>
        /// Deserializes Trx 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns>T</returns>
        public static TestRun Deserialize(string fileName)
        {
            RemoveXmlnsAndRewriteFile(fileName);
            TestRun entity;
            var xs = new XmlSerializer(typeof(TestRun));
            using (Stream sr = File.OpenRead(fileName))
            {
                entity = (TestRun)xs.Deserialize(sr);
            }
            return entity;
        }

        /// <summary>
        /// Deletes all xmlns namespaces in xml file and and overwrites file
        /// </summary>
        /// <param name="fileName">path to file with name included</param>
        private static void RemoveXmlnsAndRewriteFile(string fileName)
        {
            Regex rgx = new Regex("xmlns=\".*?\" ?");
            var fileContent = rgx.Replace(File.ReadAllText(fileName), string.Empty);
            XDocument xdoc = XDocument.Parse(fileContent);
            xdoc.Save(fileName);
        }
    }
}
