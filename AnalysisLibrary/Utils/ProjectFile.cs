using System.Reflection;

namespace AnalysisLibrary.Utils;

public class ProjectFile
{
    public static string GetSkillsFolder() =>
        Path.Join(
            Path.GetDirectoryName(
                Path.GetFullPath(Assembly.GetExecutingAssembly().Location)),
            "SemanticSkills");
}