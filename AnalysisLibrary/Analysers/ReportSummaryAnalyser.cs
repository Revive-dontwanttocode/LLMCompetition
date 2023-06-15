using AnalysisLibrary.Constants;
using Microsoft.SemanticKernel;

namespace AnalysisLibrary.Analysers;

/**
 * <summary>总结研报的分析器</summary>
 */

public class ReportSummaryAnalyser
{
    public async Task<string> ReportSummaryAsync(string reportContext)
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
            var reportSummarySkill = kernel.ImportSemanticSkillFromDirectory(
                // ProjectFile.GetSkillsFolder(),
                "D:\\Projects\\C#_Projects\\LLMCompetition\\AnalysisLibrary\\SemanticSkills",
                "SummarizeSkill");

            var result = await kernel
                .RunAsync(reportContext, reportSummarySkill["SummaryReport"]);

            var answer = result.Result;
            return answer;
    }
}