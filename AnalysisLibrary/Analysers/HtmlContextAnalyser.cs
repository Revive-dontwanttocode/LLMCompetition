using AnalysisLibrary.Constants;
using Microsoft.SemanticKernel;

namespace AnalysisLibrary.Analysers;

public class HtmlContextAnalyser
{
    public async Task<string> AnalyseAsync(string html)
    {
        var kernel = new KernelBuilder().Configure(p =>
        {
            p.AddAzureChatCompletionService(
                LlmInfoConstants.AOAI_DEPLOYMENTNAME,
                LlmInfoConstants.AOAI_ENDPOINT,
                LlmInfoConstants.AOAI_KEY
            );
        }).Build(); // 得到kernel

        var htmlContextAnalyseSkill = 
            kernel.ImportSemanticSkillFromDirectory(
            "D:\\Projects\\C#_Projects\\LLMCompetition\\AnalysisLibrary\\SemanticSkills",
            "SearchInformationSkill")["ExtractContextFromDivSkill"];
        
        var result = await kernel.RunAsync(html, htmlContextAnalyseSkill);
        var answer = result.Result;
        return answer;
    }
}