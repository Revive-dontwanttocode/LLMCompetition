using AnalysisLibrary.Analysers;
using Xunit;
using Xunit.Abstractions;

namespace AnalysisLibrary.UnitTest.Analysers;

public class ExtractCommentAnalyserTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ExtractCommentAnalyserTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task TestCommentExtractFunction()
    {
        var html = File.ReadAllText("D:\\Projects\\C#_Projects\\LLMCompetition\\AnalysisLibrary.UnitTest\\Static\\html\\002261index.html");

        var fundPortionSearch = new ExtractCommentAnalyser();
        var result = await fundPortionSearch.AnalyseAsync(html);
        _testOutputHelper.WriteLine($"======================\n{result}");
    }
}