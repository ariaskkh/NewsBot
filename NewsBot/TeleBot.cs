using Telegram.Bot;

namespace NewsBot;

public class TeleBot
{
    private readonly TelegramBotClient bot;
    Action<string> log;
    public TeleBot(string accessToken, Action<string> log)
    {
        bot = new TelegramBotClient(accessToken);
        this.log = log;
    }

    public async Task Start()
    {
        var me = await bot.GetMeAsync();
        log.Invoke($"hihi. {me.Id}, {me.Username}");
    }

    public Task Stop()
    {
        return Task.CompletedTask;
    }
}
