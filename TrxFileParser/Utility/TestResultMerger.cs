using System.Collections.Generic;
using System.IO;
using System.Linq;
using TrxFileParser.Models;

namespace TrxFileParser.Utility
{
    public static class TestResultMerger
    {
        /// <summary>
        /// Deserializes test results from multiple TRX files and returns the combined unit test results. 
        /// </summary>
        /// <remarks>Metadata from the test runs is discarded, and only the test results are returned.</remarks>
        /// <param name="trxFileContents">The contents of one or more TRX files.</param>
        /// <returns>A merged list of UnitTestResult.</returns>
        public static IReadOnlyList<UnitTestResult> DeserializeTestResultsFromMultipleFiles(IEnumerable<string> trxFileContents) =>
            trxFileContents.Select(TrxDeserializer.DeserializeContent)
                .SelectMany(t => t.Results.UnitTestResults)
                .ToArray();
        
        /// <summary>
        /// Deserializes test results from multiple TRX files and returns the combined unit test results. 
        /// </summary>
        /// <remarks>Metadata from the test runs is discarded, and only the test results are returned.</remarks>
        /// <param name="trxFilePaths">The file paths to parse.</param>
        /// <returns>A merged list of UnitTestResult.</returns>
        public static IReadOnlyList<UnitTestResult> DeserializeTestResultsFromMultipleFilePaths(IEnumerable<string> trxFilePaths) =>
            DeserializeTestResultsFromMultipleFiles(trxFilePaths.Select(File.ReadAllText));
    }
}