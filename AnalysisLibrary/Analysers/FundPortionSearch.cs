using AnalysisLibrary.Constants;
using AnalysisLibrary.NaiveSkills;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;

namespace AnalysisLibrary.Analysers;

public class FundPortionSearch
{
    public async Task<string> GetFundPortion(string fundName)
    {
        var kernel = new KernelBuilder().Configure(p =>
        {
            p.AddAzureChatCompletionService(
                LlmInfoConstants.AOAI_DEPLOYMENTNAME,
                LlmInfoConstants.AOAI_ENDPOINT,
                LlmInfoConstants.AOAI_KEY
            );
        }).Build();
        
        kernel.ImportSkill(new DateTimeSkill(), "DateTimeSkill");

        var fundPortionSkill = kernel.ImportSemanticSkillFromDirectory(
            // ProjectFile.GetSkillsFolder(),
            "D:\\Projects\\C#_Projects\\LLMCompetition\\AnalysisLibrary\\SemanticSkills",
            "SearchInformationSkill")["FundPortionSearch"];

        var variables = new ContextVariables(fundName);
        variables["todayDate"] = DateTime.Now.ToString("yyyy-MM-dd");
        
        var searchResult = await kernel.RunAsync(variables, fundPortionSkill);
        var answer = searchResult.Result;
        return answer;
    }
}