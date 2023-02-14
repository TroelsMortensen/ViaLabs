using System.Text;
using System.Text.RegularExpressions;

namespace BlazorServerUI.MarkdownConvert.SubHandlers;

public static class InsertNumberedRingSteps 
{
    public static void Handle(StringBuilder builder)
    {
        Regex pattern = new(@"\(\(\d*\)\)");
        MatchCollection matchCollection = pattern.Matches(builder.ToString());
        foreach (Match match in matchCollection)
        {
            string theMatch = match.Value;
            string stepNumber = theMatch.Replace("((", "").Replace("))", "");
            string replacementHtml = $"<span class=\"numberCircle\"><span>{stepNumber}</span></span>";
            builder.Replace(theMatch, replacementHtml);
        }
    }
}