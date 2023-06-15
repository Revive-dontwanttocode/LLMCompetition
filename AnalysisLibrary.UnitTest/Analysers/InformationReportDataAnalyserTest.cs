using AnalysisLibrary.Analysers;
using Xunit;
using Xunit.Abstractions;

namespace AnalysisLibrary.UnitTest.Analysers;

public class InformationReportDataAnalyserTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public InformationReportDataAnalyserTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void ReportDataAnalyseTest()
    {
        var context =
            "沪深交易所2023年06月09日公布的交易公开信息显示，沪电股份因成为当日涨幅偏离值达7%的证券上榜。沪电股份当日收报21.81元，涨跌幅9.98%，偏离值9.29%，换手率6.57%，成交额26.11亿元。";
        var informationReportDataAnalyser = new InformationReportDataAnalyser();
        _testOutputHelper.WriteLine($"要解析的文段为：\n{context}");
        _testOutputHelper.WriteLine($"解析结果：\n{await informationReportDataAnalyser.ReportDataAnalyseAsync(context)}");
    }
}