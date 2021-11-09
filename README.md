![documents](https://user-images.githubusercontent.com/8418700/140908176-4541457e-862e-4cbc-a946-139fb75f211c.png)

A `Trx` file is nothing but a Visual Studio unit test result file extension. This file is in XML format. `TrxFileParser` helps you to parse it.

### Create a Trx file

* Command line

```
dotnet test -l:trx;LogFileName=C:\temp\TestOutput.xml
```

* MSBuild

```xml
<PropertyGroup>
  <VSTestLogger>trx</VSTestLogger>
  <VSTestResultsDirectory>C:\temp</VSTestResultsDirectory>
</PropertyGroup>
```

### Parsing a Trx file

```cs
TestRun testRun = TrxFileParser.TrxConvert.Deserialize(trxFilePath);
```

### Convert test result to Markdown

```cs
string markdown = testRun.ToMarkdown();
```

<hr/>
<div>Icons made by <a href="https://www.freepik.com" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>
