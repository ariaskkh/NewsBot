using NewsCrawling.Models;
using PuppeteerSharp;

namespace NewsCrawling;

public class YahooFinanceCrawler
{
    private Action<string> log;
    private readonly List<NewsKeyword> keywordList = []; // TODO: 인메모리가 아니라 파일이나 db에 저장하기
    public List<NewsKeyword> KeywordList => keywordList;

    public YahooFinanceCrawler(Action<string> Log)
    {
        log = Log;
    }

    public async Task CrawlYahooNews()
    {
        // Download and Launch headless Chrome (Chromium)
        await new BrowserFetcher().DownloadAsync();

        using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });


        using var page = await browser.NewPageAsync();
        
        log.Invoke("before GoToAsync");

        // 거의 20초 걸림. 원래 이런가?
        await page.GoToAsync("https://finance.yahoo.com/news/");

        log.Invoke("after GoToAsync");

        // 검색 시간 간격에 맞게 최적화 할 수 있을 듯.
        int scrollTimes = 5;
        for (int i = 0; i < scrollTimes; i++)
        {
            await page.EvaluateExpressionAsync("window.scrollBy(0, window.innerHeight);");
            await Task.Delay(1000);
        }

        log.Invoke("3");

        // 뉴스 기사의 사진에도 a[href*='/news/']에 포함되는 태그가 있어 최적화 할 수 있음.
        var newsItems = await page.EvaluateFunctionAsync<List<NewsItem>>(@"() => {
            let articles = [];
            let items = document.querySelectorAll(""a[href*='/news/'] h3"");
            items.forEach(item => {
                let title = item.innerText;
                let url = item.closest('a').href;
                articles.push({ title, url});
            });
            return articles;
        }");

        log.Invoke("4");

        foreach (var item in newsItems)
        {
            log.Invoke($"Title: {item.Title}");
            log.Invoke($"URL: {item.Url}");
            log.Invoke(Environment.NewLine);
        }
    }

    public bool AddKeyword(string newKeyword)
    {
        if (keywordList.All(keyword => keyword.text != newKeyword))
        {
            keywordList.Add(new NewsKeyword(newKeyword));
            log.Invoke($"keyword '{newKeyword}' is added successfully");
            return true;
        }
        else
        {
            log.Invoke($"keyword '{newKeyword}' already exists in the list");
            return false;
        }
    }

    public bool RemoveKeyword(string newKeyword)
    {
        if (keywordList.Any(keyword => keyword.text == newKeyword))
        {
            var index = keywordList.FindIndex(keyword => keyword.text == newKeyword);
            keywordList.RemoveAt(index);
            log.Invoke($"keyword '{newKeyword}' is removed successfully");
            return true;
        }
        else
        {
            log.Invoke($"keyword '{newKeyword}' does not exist in the list");
            return false;
        }
    }
}