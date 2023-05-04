using FluentAssertions;
using TrxFileParser.Models;

namespace TrxFileParserTests.Utility;

public class InnerResultsTests
{
	[Test]
	public void Given_a_test_with_multiple_cases_inner_results_load_correctly()
	{
		var content = TestResultMergerTests.LoadSampleTrxFile("TestWithCases.trx");

		var expectedInnerResults = new List<UnitTestResult>
		{
			new UnitTestResult
			{
				TestName = "Given_a_test_with_multiple_cases_inner_results_load_correctly",
				Id = "ff87441c-1542-4a96-a041-08ddda2abb87",
				ParentId = "b0bda35d-15a7-4abd-a975-cf3ed47597b2",
				ComputerName = "SOMETESTPC",
				StartTime = "2022-09-23T06:07:17.7806675+12:00",
				EndTime = "2022-09-23T06:12:17.7823048+12:00",
				Duration = "00:05:00.0016900",
				Outcome = "Passed",
				RelativeResultsDirectoryId = "ff87441c-1542-4a96-a041-08ddda2abb87",
				TestId = "a5a3dae4-4114-cafa-46c2-9705a0b04c7c",
				TestListId = "8c84fa94-04c1-424b-9868-57a2d4851a1d",
				TestTypeId = "13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b",
				DataRowInfo = "1",
				ResultType = "DataDrivenDataRow",
				Output = null
			},
			new UnitTestResult
			{
				TestName = "Given_a_test_with_multiple_cases_inner_results_load_correctly",
				Id = "1c5e49de-486e-4eba-93fc-79c659d7bf9b",
				ParentId = "b0bda35d-15a7-4abd-a975-cf3ed47597b2",
				ComputerName = "SOMETESTPC",
				StartTime = "2022-09-23T06:12:17.7806675+12:00",
				EndTime = "2022-09-23T06:17:17.7823048+12:00",
				Duration = "00:05:00.0016900",
				Outcome = "Passed",
				RelativeResultsDirectoryId = "1c5e49de-486e-4eba-93fc-79c659d7bf9b",
				TestId = "a5a3dae4-4114-cafa-46c2-9705a0b04c7c",
				TestListId = "8c84fa94-04c1-424b-9868-57a2d4851a1d",
				TestTypeId = "13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b",
				DataRowInfo = "2",
				ResultType = "DataDrivenDataRow",
				Output = null
			}
		};

		var expectedOuterResult = new UnitTestResult
		{
			TestName = "Given_a_test_with_multiple_cases_inner_results_load_correctly",
			Id = "b0bda35d-15a7-4abd-a975-cf3ed47597b2",
			ComputerName = "SOMETESTPC",
			StartTime = "2022-09-23T06:07:17.7806675+12:00",
			EndTime = "2022-09-23T06:17:17.7823048+12:00",
			Duration = "00:10:00.0016900",
			Outcome = "Passed",
			RelativeResultsDirectoryId = "b0bda35d-15a7-4abd-a975-cf3ed47597b2",
			TestId = "a5a3dae4-4114-cafa-46c2-9705a0b04c7c",
			TestListId = "8c84fa94-04c1-424b-9868-57a2d4851a1d",
			TestTypeId = "13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b",
			ResultType = "DataDrivenTest",
			Output = null,
			InnerResults = new Results { UnitTestResults = expectedInnerResults }
		};

		var run = TrxFileParser.TrxDeserializer.DeserializeContent(content);
		run.Results.UnitTestResults.Should().ContainSingle();

		var unitTestResult = run.Results.UnitTestResults.Single();
		unitTestResult.Should().BeEquivalentTo(expectedOuterResult,
			o => o.ComparingByMembers(typeof(UnitTestResult)));
	}
}