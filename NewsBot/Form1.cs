using Microsoft.Extensions.Configuration;
using NewsCrawling;

namespace NewsBot
{
    public partial class Form1 : Form
    {
        private readonly TeleBot teleBot;
        private Action<string> Log { get; set; }
        private readonly YahooFinanceCrawler yahooCrawler;

        public Form1(IConfiguration config)
        {
            InitializeComponent();
            // TODO: 클래스에서 다양한 형태 log 만들 수 있게 만들기
            Log = message => textBox1.AppendText($"{DateTime.Now}: {message}{Environment.NewLine}");
            
            var token = config.GetSection("TelegramBot").GetValue<string>("AccessToken") ?? string.Empty;
            long chatId = config.GetSection("TelegramBot").GetValue<long>("ChatId");
            teleBot = new TeleBot(token, chatId, Log);
            yahooCrawler = new YahooFinanceCrawler(Log);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Start_Click(object sender, EventArgs e)
        {
            //await teleBot.Start();
            yahooCrawler.CrawlYahooNews();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            teleBot.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
