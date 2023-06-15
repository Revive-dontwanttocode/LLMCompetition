using AnalysisLibrary.Analysers;
using Xunit;
using Xunit.Abstractions;

namespace AnalysisLibrary.UnitTest.Analysers;

public class HtmlContextAnalyserTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public HtmlContextAnalyserTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task Test()
    {
        var html = File.ReadAllText("D:\\Projects\\C#_Projects\\LLMCompetition\\AnalysisLibrary.UnitTest\\Static\\html\\all.html");
        var analyser = new HtmlContextAnalyser();
        var result = await analyser.AnalyseAsync(html);
        _testOutputHelper.WriteLine(result);
    }
}