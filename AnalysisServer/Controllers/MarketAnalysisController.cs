using AnalysisServer.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AnalysisServer.Controllers;

[ApiController]
[Route(("api/[controller]/[action]"))]
public class MarketAnalysisController
{
    private IMarketAnalyzeService _marketAnalyzeService;

    public MarketAnalysisController(IMarketAnalyzeService marketAnalyzeService)
    {
        _marketAnalyzeService = marketAnalyzeService;
    }

    /**
     * 
     * 文章标题归类
     */
    [HttpGet(Name = "HeaderClassify")]
    public async Task<IActionResult> HeaderClassifyAsync([FromQuery] string header)
    {
        var headerClassifyResult = await _marketAnalyzeService.HeaderClassifyAsync(header);
        JObject json = new JObject();
        json.Add("code", "1");
        json.Add("msg", headerClassifyResult);
        json.Add("time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        return new ContentResult
        {
            Content = json.ToString(),
            ContentType = "application/json"
        };
    }

    /**
     * @api {post} /api/MarketAnalysis/ContentAbstract 文章内容摘要
     */
    [HttpGet(Name = "ContentAbstract")]
    public async Task<ActionResult> ContentAbstractAsync([FromQuery] string content)
    {
        var contentAbstractResult = await _marketAnalyzeService.ContentAbstractAsync(content);
        JObject json = new JObject();
        json.Add("code", "1");
        json.Add("msg", contentAbstractResult);
        json.Add("time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        return new ContentResult
        {
            Content = json.ToString(),
            ContentType = "application/json"
        };
    }

    /**
     * @api {get} /api/MarketAnalysis/EmotionAnalysis 文章情感分析
     */
    [HttpGet(Name = "EmotionAnalyse")]
    public async Task<ActionResult> EmotionAnalyseAsync([FromQuery] string content)
    {
        var emotionAnalyseResult = await _marketAnalyzeService.EmotionAnalyzeAsync(content);
        JObject json = new JObject();
        json.Add("code", "1");
        json.Add("msg", emotionAnalyseResult);
        json.Add("time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        return new ContentResult
        {
            Content = json.ToString(),
            ContentType = "application/json"
        };
    }
}