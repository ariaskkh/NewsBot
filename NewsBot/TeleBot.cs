using Telegram.Bot;

namespace NewsBot;

public class TeleBot
{
    private readonly TelegramBotClient bot;
    private Action<string> log;
    private readonly long chatId = 0;
    public TeleBot(string accessToken, long chatId, Action<string> log)
    {
        bot = new TelegramBotClient(accessToken);
        this.log = log;
        this.chatId = chatId;
    }

    public async Task Start()
    {
        var me = await bot.GetMeAsync();
        log.Invoke($"hihi. {me.Id}, {me.Username}");
        await SendMessage("heyheyehy");
    }

    public Task Stop()
    {
        return Task.CompletedTask;
    }

    public async Task SendMessage(string message)
    {
        try
        {
            await bot.SendTextMessageAsync(chatId, message);
            log.Invoke($"Message sent to chat Id: {chatId}");
        }
        catch (Exception ex)
        {
            log.Invoke($"Error sending message: {ex.Message}");
        }

    }
}
