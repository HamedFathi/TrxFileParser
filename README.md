```cs
TestRun testRun = TrxFileParser.TrxConvert.Deserialize(trxFilePath);

string markdown = testRun.ToMarkdown();
```