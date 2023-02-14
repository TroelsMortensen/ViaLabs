using System.Text;

namespace BlazorServerUI.MarkdownConvert.SubHandlers;

internal static class AddLineNumberCssClassToCodeTag 
{
    internal static void Handle(StringBuilder basePage)
    {
        basePage.Replace("class=\"language-", "class=\"line-numbers language-");
    }
}