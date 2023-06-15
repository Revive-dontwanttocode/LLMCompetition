using AnalysisLibrary.Constants;
using Microsoft.SemanticKernel;

namespace AnalysisLibrary.Analysers;

public class NewsSummaryAnalyser
{
    public async Task<string> NewsSummary(string news)
    {
        var kernel = new KernelBuilder().Configure(p =>
        {
            p.AddAzureChatCompletionService(
                LlmInfoConstants.AOAI_DEPLOYMENTNAME,
                LlmInfoConstants.AOAI_ENDPOINT,
                LlmInfoConstants.AOAI_KEY
            );
        }).Build(); // 得到kernel
        
        // load skill
        var newsSummarySkill = kernel.ImportSemanticSkillFromDirectory(
            // ProjectFile.GetSkillsFolder(),
            "D:\\Projects\\C#_Projects\\LLMCompetition\\AnalysisLibrary\\SemanticSkills",
            "SummarizeSkill")["SummaryNews"];

        var result = await kernel.RunAsync(news, newsSummarySkill);
        var answer = result.Result;
        
        return answer;
    }
}