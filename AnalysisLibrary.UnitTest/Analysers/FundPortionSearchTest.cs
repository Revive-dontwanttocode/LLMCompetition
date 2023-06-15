using AnalysisLibrary.Analysers;
using Xunit;
using Xunit.Abstractions;

namespace AnalysisLibrary.UnitTest.Analysers;

public class FundPortionSearchTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public FundPortionSearchTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task TestGetFundPortion()
    {
        var fundName = "中欧医疗健康混合C";
        _testOutputHelper.WriteLine($"基金名称：{fundName}");
        _testOutputHelper.WriteLine($"当前日期：{DateTime.Now.ToString("yyyy-MM-dd")}");
        var fundPortionSearch = new FundPortionSearch();
        var result = await fundPortionSearch.GetFundPortion(fundName);
        _testOutputHelper.WriteLine(result);
    }
}
