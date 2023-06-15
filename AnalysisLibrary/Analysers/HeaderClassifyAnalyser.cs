using AnalysisLibrary.Constants;
using Microsoft.SemanticKernel;

namespace AnalysisLibrary.Analysers;

public class HeaderClassifyAnalyser
{
    public async Task<string> HeaderClassify(string header)
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
        var headerClassifySkill = kernel.ImportSemanticSkillFromDirectory(
            // ProjectFile.GetSkillsFolder(),
            "D:\\Projects\\C#_Projects\\LLMCompetition\\AnalysisLibrary\\SemanticSkills",
            "AnalysisHeaderSkill");
        
        var result = await kernel.RunAsync(header, headerClassifySkill["HeaderClassify"]);
        var answer = result.Result;

        return answer;
    }
}