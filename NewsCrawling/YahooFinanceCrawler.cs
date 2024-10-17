using NewsCrawling.Models;
using PuppeteerSharp;

namespace NewsCrawling;

public class YahooFinanceCrawler
{
    Action<string> log;
    public YahooFinanceCrawler(Action<string> Log)
    {
        log = Log;
    }


    public async Task CrawlYahooNews()
    {
        // Download and Launch headless Chrome (Chromium)
        await new BrowserFetcher().DownloadAsync();

        log.Invoke("1");
        using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });

        log.Invoke("1.2");

        using var page = await browser.NewPageAsync();
        
        log.Invoke("1.5");

        // 거의 20초 걸림. 원래 이런가?
        await page.GoToAsync("https://finance.yahoo.com/news/");

        log.Invoke("2");

        int scrollTimes = 5;
        for (int i = 0; i < scrollTimes; i++)
        {
            await page.EvaluateExpressionAsync("window.scrollBy(0, window.innerHeight);");
            await Task.Delay(1000);
        }

        log.Invoke("3");

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
}