using System.Text;
using System.Text.RegularExpressions;

namespace BlazorServerUI.MarkdownConvert.SubHandlers;

public static class MoveLineHighlightingAttributes 
{
    public static void Handle(StringBuilder builder)
    {
        // Regex pattern = new Regex("<pre><code class=\"line-numbers language-(?<language>[a-z]){0,15}\\{\\d\\}\">");
        Regex pattern = new Regex("<pre><code class=\"line-numbers language-[a-z]{0,15}{(.*?)}\">");
        MatchCollection matchCollection = pattern.Matches(builder.ToString());
        foreach (Match match in matchCollection)
        {
            string existingHtml = match.Value;
            // Regex regex = new Regex("{(.*?)}");
            // Match dataLineValueMatch = regex.Match(existingHtml);
            string dataLineValue = match.Groups[1].Value;

            string replacementHtml = Regex.Replace(existingHtml, @"{(.*?)}", "");
            replacementHtml = replacementHtml.Replace("pre", $"pre data-line=\"{dataLineValue}\"");
            builder.Replace(existingHtml, replacementHtml);
        }
    }
}