using AnalysisLibrary.Constants;
using Microsoft.SemanticKernel;

namespace AnalysisLibrary.Analysers;

public class EmotionWordsAnalyser
{
    public async Task<string> EmotionWordsCount(string context)
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
            "AnalysisContentSkill");
        
        var result = await kernel.RunAsync(context, headerClassifySkill["ContentEmotion"]);
        var answer = result.Result;

        return answer;
    }
}