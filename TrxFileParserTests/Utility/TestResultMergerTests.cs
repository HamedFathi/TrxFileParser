using System.Reflection;
using FluentAssertions;
using Microsoft.Extensions.FileProviders;
using TrxFileParser.Models;
using TrxFileParser.Utility;

namespace TrxFileParserTests.Utility;

public class TestResultMergerTests
{
    [Test]
    public void Given_a_single_trx_file_content_When_merging_Then_return_the_unit_test_results_from_that_file()
    {
        var content = LoadSampleTrxFile("SingleTestPassed.trx");
        var unitTests = TestResultMerger.DeserializeTestResultsFromMultipleFiles(new[] { content });
        unitTests.Should().BeEquivalentTo(
            new []
            {
                new UnitTestResult
                {
                    TestName = "Given_a_single_trx_file_content_When_merging_Then_return_the_unit_test_results_from_that_file",
                    Id = "b0bda35d-15a7-4abd-a975-cf3ed47597b2",
                    ComputerName = "SOMETESTPC",
                    StartTime = "2022-09-23T06:07:17.7806675+12:00",
                    EndTime = "2022-09-23T06:07:17.7823048+12:00",
                    Duration = "00:00:00.0016900",
                    Outcome = "Passed",
                    RelativeResultsDirectoryId = "b0bda35d-15a7-4abd-a975-cf3ed47597b2",
                    TestId = "a5a3dae4-4114-cafa-46c2-9705a0b04c7c",
                    TestListId = "8c84fa94-04c1-424b-9868-57a2d4851a1d",
                    TestTypeId = "13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b",
                    Output = null
                }
            });
    }

    internal static string LoadSampleTrxFile(string name)
    {
        var provider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly(), "TrxFileParserTests.SampleTrxFiles");
        var file = provider.GetDirectoryContents("/").Single(f => f.Name == name);
        using var stream = file.CreateReadStream();
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}