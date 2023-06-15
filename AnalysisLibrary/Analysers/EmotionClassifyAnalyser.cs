using AnalysisLibrary.Constants;
using Microsoft.SemanticKernel;

namespace AnalysisLibrary.Analysers;

public class EmotionClassifyAnalyser
{
    public async Task<string> GetEmotion(string content)
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
        var getEmotionSkill = kernel.ImportSemanticSkillFromDirectory(
            // ProjectFile.GetSkillsFolder(),
            "D:\\Projects\\C#_Projects\\LLMCompetition\\AnalysisLibrary\\SemanticSkills",
            "AnalysisHeaderSkill")["HeaderEmotionClassify"];
        
        var result = await kernel.RunAsync(content, getEmotionSkill);
        var answer = result.Result;
        
        return answer;
    }
}