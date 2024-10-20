namespace NewsCrawling.Models;

public class NewsKeyword
{
    public string text { get; set; }

    public NewsKeyword(string text)
    {
        this.text = text;
    }
}
