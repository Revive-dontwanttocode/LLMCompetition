using AnalysisLibrary.Analysers;
using Xunit;
using Xunit.Abstractions;

namespace AnalysisLibrary.UnitTest.Analysers;

public class NewsSummaryAnalyserTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public NewsSummaryAnalyserTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task NewsSummaryTest()
    {
        var newsSummaryAnalyser = new NewsSummaryAnalyser();
        var news =
@"6月14日下午，A股收市，全天行情窄幅震荡，三大指数涨跌不一，上证指数收跌0.14%，深证成指收涨0.26%，创业板指收跌0.17%。当天，两市成交额10006亿元，时隔26个交易日重回万亿上方，较上一交易日放量583亿元；北向资金净卖出近22亿元，大盘资金净流出超273亿元。两市股票呈现跌多涨少的态势，2169只股票上涨，2791只股票下跌。其中，56只涨停股、3只跌停股。板块方面，饮料制造、通信设备、医药商业、酒店及餐饮、美容护理、汽车服务、零售等行业及CPO、F5G、白酒、社区团购、预制菜等概念股走强。其中，白酒股大幅反弹，大湖股份2连板，古越龙山涨停，老白干酒涨超7%，古井贡酒涨超4%，泸州老窖涨超3%，贵州茅台涨超1%；CPO概念股持续强势，仕佳光子午后20cm涨停，天孚通信涨超16%，源杰科技、太辰光涨近15%，长光华芯涨近13%，永鼎股份、光迅科技涨停；零售股盘中发力，三江购物2连板，国光连锁、人人乐、小商品城涨停；算力概念股午后冲高，浪潮信息大涨超6%续创新高。电力、银行、电力设备、机场航运等行业及虚拟电厂、抽水蓄能、智慧杆灯、高压快充等概念股跌幅居前。其中，电力股持续走低，杭州热电跌超6%，浙能电力跌超5%；银行股表现低迷，邮储银行跌超4%，北京银行、农业银行跌约3%，建设银行、工商银行、交通银行跌超2%。创业板新股康力源上市首日高开，收涨25.55%。";
        _testOutputHelper.WriteLine($"待总结的新闻为：\n{news}");
        var result = await newsSummaryAnalyser.NewsSummary(news);
        _testOutputHelper.WriteLine($"总结结果为：\n{result}");
    }
}