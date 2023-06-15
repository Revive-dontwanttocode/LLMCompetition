namespace AnalysisServer.Services;

public interface IStockAnalyzeService
{
    Task<string> HeaderClassifyAsync(string header); // 文章标题分类
    
    Task<string> SummarizeReportAsync(string report); // 研报摘要

    Task<string> ReportDataExtractAsync(string report); // 文段数据提取
    
    Task<string> ReportKeywordsExtractAsync(string report); // 关键词提取
}