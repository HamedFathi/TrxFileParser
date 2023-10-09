
> **For those who use this library, I highly recommend trying [VSTest](https://github.com/HamedStack/HamedStack.VSTest). This library supports more details.**

![search](https://user-images.githubusercontent.com/8418700/140909729-b376f550-469b-426d-8d7d-b78cfee45350.png)

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

### [Nuget](https://www.nuget.org/packages/TrxFileParser/)

[![Open Source Love](https://badges.frapsoft.com/os/mit/mit.svg?v=102)](https://opensource.org/licenses/MIT)
![Nuget](https://img.shields.io/nuget/v/TrxFileParser)
![Nuget](https://img.shields.io/nuget/dt/TrxFileParser)

```
Install-Package TrxFileParser

dotnet add package TrxFileParser
```

<hr/>
<div>Icons made by <a href="https://www.freepik.com" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>
