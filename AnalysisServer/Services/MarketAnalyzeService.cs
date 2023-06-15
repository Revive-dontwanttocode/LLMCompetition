using AnalysisLibrary.Analysers;

namespace AnalysisServer.Services;

public class MarketAnalyzeService : IMarketAnalyzeService
{
    private HeaderClassifyAnalyser _headerClassifyAnalyser; // 文章标题归类

    private InformationReportDataAnalyser _informationReportDataAnalyser; // 文章数据提取

    private ReportSummaryAnalyser _reportSummaryAnalyser; // 文章内容摘要
    
    private EmotionClassifyAnalyser _emotionClassifyAnalyser; // 文章情感分类

    public MarketAnalyzeService(HeaderClassifyAnalyser headerClassifyAnalyser,
        InformationReportDataAnalyser informationReportDataAnalyser, 
        ReportSummaryAnalyser reportSummaryAnalyser,
        EmotionClassifyAnalyser emotionClassifyAnalyser)
    {
        _headerClassifyAnalyser = headerClassifyAnalyser;
        _informationReportDataAnalyser = informationReportDataAnalyser;
        _reportSummaryAnalyser = reportSummaryAnalyser;
        _emotionClassifyAnalyser = emotionClassifyAnalyser;
    }

    public async Task<string> HeaderClassifyAsync(string header)
    {
        var headerCategory = await _headerClassifyAnalyser.HeaderClassify(header);
        return headerCategory;
    }

    public async Task<string> ContentAbstractAsync(string content)
    {
        var reportSummaryAsync = await _reportSummaryAnalyser.ReportSummaryAsync(content);
        return reportSummaryAsync;
    }

    public async Task<string> DataExtractAsync(string content)
    {
        var reportData = await _informationReportDataAnalyser.ReportDataAnalyseAsync(content);
        return reportData;
    }

    public Task<string> EmotionAnalyzeAsync(string content)
    {
        var emotionResult = _emotionClassifyAnalyser.GetEmotion(content);
        return emotionResult;
    }

    public Task<string> KeywordExtractAsync(string content)
    {
        throw new NotImplementedException();
    }
}