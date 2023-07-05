using FluentAssertions;
using TrxFileParser.Models;

namespace TrxFileParserTests.Utility;

public class RunInfosTests
{
	[Test]
	public void Given_a_run_with_RunInfos_and_no_results_load_correctly()
	{
		var content = TestResultMergerTests.LoadSampleTrxFile("FrameworkFailure.trx");

		var expectedRunInfos = new List<RunInfo>
		{
			new RunInfo()
			{
				ComputerName = "SOMETESTPC",
				Outcome = "Error",
				Timestamp = "2022-09-23T06:07:17.3271181+12:00",
				Text = "\n          Testhost process exited with error: It was not possible to find any compatible framework version\r\n" +
					   "          The framework 'Microsoft.NETCore.App', version '6.0.18' (x86) was not found.\r\n" +
					   "          - The following frameworks were found:\r\n" +
					   "          3.1.16 at [C:\\Program Files (x86)\\dotnet\\shared\\Microsoft.NETCore.App]\r\n" +
					   "          3.1.19 at [C:\\Program Files (x86)\\dotnet\\shared\\Microsoft.NETCore.App]\r\n" +
					   "          3.1.32 at [C:\\Program Files (x86)\\dotnet\\shared\\Microsoft.NETCore.App]\r\n" +
					   "          5.0.7 at [C:\\Program Files (x86)\\dotnet\\shared\\Microsoft.NETCore.App]\r\n" +
					   "          5.0.10 at [C:\\Program Files (x86)\\dotnet\\shared\\Microsoft.NETCore.App]\r\n" +
					   "          5.0.17 at [C:\\Program Files (x86)\\dotnet\\shared\\Microsoft.NETCore.App]\r\n" +
					   "          6.0.4 at [C:\\Program Files (x86)\\dotnet\\shared\\Microsoft.NETCore.App]\r\n" +
					   "          You can resolve the problem by installing the specified framework and/or SDK.\r\n" +
					   "          The specified framework can be found at:\r\n" +
					   "          - https://aka.ms/dotnet-core-applaunch?framework=Microsoft.NETCore.App&framework_version=6.0.18&arch=x86&rid=win81-x86\r\n" +
					   "          . Please check the diagnostic logs for more information.\n        ",
				Exception = null
			},
			new RunInfo()
			{
				ComputerName = "SOMETESTPC",
				Outcome = "Warning",
				Timestamp = "2022-09-23T06:07:17.3271181+12:00",
				Text = "Data collector 'Blame' message: All tests finished running, Sequence file will not be generated.",
				Exception = null
			}
		};

		var run = TrxFileParser.TrxDeserializer.DeserializeContent(content);

		run.Results.Should().BeNull();
		run.ResultSummary.RunInfos.Infos.Should().BeEquivalentTo(expectedRunInfos);
	}

	[Test]
	public void Given_a_run_with_no_RunInfos_load_correctly()
	{
		var content = TestResultMergerTests.LoadSampleTrxFile("SingleTestPassed.trx");

		var run = TrxFileParser.TrxDeserializer.DeserializeContent(content);

		run.Results.Should().NotBeNull();
		run.ResultSummary.RunInfos.Should().BeNull();
	}
}