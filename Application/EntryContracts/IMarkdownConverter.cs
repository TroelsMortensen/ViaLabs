namespace Application.EntryContracts;

public interface IMarkdownConverter
{
    public string ConvertMdToHtml(string mdContent);
}