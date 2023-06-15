using Microsoft.SemanticKernel.SkillDefinition;

namespace AnalysisLibrary.NaiveSkills;

public class DateTimeSkill
{
    [SKFunction("Get Today's date")]
    public string GetTodayDate()
    {
        return DateTime.Now.ToString("yyyy-MM-dd");
    }
}