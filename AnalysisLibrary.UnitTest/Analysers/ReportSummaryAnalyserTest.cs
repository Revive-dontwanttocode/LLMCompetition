using AnalysisLibrary.Analysers;
using Xunit;
using Xunit.Abstractions;

namespace AnalysisLibrary.UnitTest.Analysers;

public class ReportSummaryAnalyserTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ReportSummaryAnalyserTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task Run()
    {
        var reportContext = @"中信建投陈果：反攻！又到战略乐观时

            前期我们提出权益市场具备配置吸引力，将构筑复合底部，近期随着政策预期改善、库存周期筑底预期、商品价格企稳、人民币汇率企稳和全球市场回暖等积极信号陆续出现，A股包括港股市场已经具备战略反击条件。未来一年企业盈利有望迎来较长上行周期，叠加国内降准降息可期，海外利率下行，双击之下，市场有望挑战2022年以来新高，值得战略乐观。

        重点关注方向：1）政策受益方向及前期超跌方向；2）顺周期属性高ROE方向；3）增量资金流入偏好的方向。行业推荐：汽车、家电、保险、食品饮料、传媒、通信、计算机、半导体、有色金属等。

        市场具备见底反攻条件，盈利估值双击，有望挑战2022年以来新高。从市场空间底模型来看，目前市场已跌至M2折算底部附近，宏观流动性将为市场提供坚实的支撑。PPI跌至周期底部，企业盈利逐步回暖。1）由于基数原因和环比改善，PPI同比或将在5-6月见底并有望在7月回升。2）从历史上看，PPI同比和CRB指数同比趋势一致，均呈现出3.5年小周期（库存周期）和7年大周期（产业周期）的规律。我们认为PPI同比见底的同时也是工业企业利润见底回升的契机，将迎来较长上升周期。利率环境相对友好，双击之下有望挑战2022年以来新高。

        近期积极信号已在持续出现：1）人民币汇率出现企稳迹象；2）库存周期底部渐行渐近，南华商品指数出现上涨；3）疫情过峰，经济环境边际改善；4）中美外交层面出现积极信号，国内政策预期有所提升；5）本周市场有所缩量，呈现底部特征。随着积极信号陆续出现，我们认为投资者可以更加积极的参与到战略反攻当中。

        近期政策频繁出台呵护稳增长，回顾16年来五次经济预期降至冰点而后逐步修正的市场表现，市场急跌期因经济预期悲观顺周期链平均跌幅靠前，而预期反转、市场反转一个月期间内，政策受益方向及前期超跌方向整体超额收益则相应领先，主要包括顺周期属性高ROE的食品饮料、地产链、以及汽车/家电等大宗耐用品；周期板块虽也受益经济预期修正带来的盈利预期好转，但整体表现居中。从资金维度出发，近期北向资金配置盘对建筑装饰、建筑材料、家电行业持续增持，TMT板块也出现流入加速的迹象。";
        
        var reportSummaryAnalyser = new ReportSummaryAnalyser();
        _testOutputHelper.WriteLine($"要总结的研报为：\n{reportContext}");
        _testOutputHelper.WriteLine($"{await reportSummaryAnalyser.ReportSummaryAsync(reportContext)}");
    }
}