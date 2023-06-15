using Microsoft.SemanticKernel;

namespace AnalysisServer.Services;

public class StockAnalyzeService : IStockAnalyzeService
{
    private IKernelFactory _kernelFactory;

    /**
     * 依赖注入
     */
    public StockAnalyzeService(IKernelFactory kernelFactory)
    {
        _kernelFactory = kernelFactory;
    }

    /**
     * 标题分类Skill
     */
    public async Task<string> HeaderClassifyAsync(string header)
    {
        return header;
    }

    /**
     * 研报摘要
     */
    public async Task<string> SummarizeReportAsync(string report)
    {
        throw new NotImplementedException();
    }

    /**
     * 文段数据提取
     */
    public async Task<string> ReportDataExtractAsync(string report)
    {
        throw new NotImplementedException();
    }

    /**
     * 关键词提取
     */
    public async Task<string> ReportKeywordsExtractAsync(string report)
    {
        throw new NotImplementedException();
    }
}