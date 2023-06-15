namespace AnalysisServer.Services;

public interface IMarketAnalyzeService
{
    public Task<string> HeaderClassifyAsync(string header); // 文章标题归类
    
    public Task<string> ContentAbstractAsync(string content); // 文章内容摘要
    
    public Task<string> DataExtractAsync(string content); // 文章数据提取
    
    public Task<string> EmotionAnalyzeAsync(string content); // 文章情感分析
    
    public Task<string> KeywordExtractAsync(string content); // 文章关键词提取
}