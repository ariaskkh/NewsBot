using Microsoft.Extensions.Configuration;

namespace NewsBot
{
    public partial class Form1 : Form
    {
        private readonly TeleBot teleBot;
        private Action<string> Log { get; set; }

        public Form1(IConfiguration config)
        {
            InitializeComponent();
            Log = message => textBox1.AppendText($"{DateTime.Now}: {message}{Environment.NewLine}");
            
            var token = config.GetSection("TelegramBot").GetValue<string>("AccessToken") ?? string.Empty;
            teleBot = new TeleBot(token, Log);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Start_Click(object sender, EventArgs e)
        {
            teleBot.Start();
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
