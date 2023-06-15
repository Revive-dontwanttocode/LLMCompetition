using AnalysisLibrary.Analysers;
using Xunit;
using Xunit.Abstractions;

namespace AnalysisLibrary.UnitTest.Analysers;


public class HeaderClassifyAnalyserTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public HeaderClassifyAnalyserTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task Run()
    {
        var header = "上海物贸明日冲高可以考虑止盈，甘蔗只吃最甜的中间一节，再妖连板上去也无所谓了";
        var headerClassifyAnalyser = new HeaderClassifyAnalyser();
        _testOutputHelper.WriteLine($"要归类的标题是：{header}");
        _testOutputHelper.WriteLine($"标题分类：{await headerClassifyAnalyser.HeaderClassify(header)}");
    }
}