namespace NewsCrawling.Models;

internal class NewsKeyword
{
    public string text { get; set; }

    public NewsKeyword(string text)
    {
        this.text = text;
    }
}
