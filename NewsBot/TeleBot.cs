using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

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

        await SetBotCommands();

        bot.OnMessage += OnMessage;
        bot.OnError += OnError;
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

    private async Task OnMessage(Telegram.Bot.Types.Message msg, UpdateType type)
    {
        if (msg.Text == "/keywords")
        {
            await bot.SendTextMessageAsync(
                chatId: msg.Chat,
                text: "hihi, you said keywords !");
        }
    }

    private async Task OnError(Exception exception, HandleErrorSource source)
    {
        log.Invoke(exception.Message);
    }

    private async Task SetBotCommands()
    {
        var commands = new BotCommand[]
        {
            new BotCommand { Command = "keywords", Description = "Show Keywords Added" },
        };
        await bot.SetMyCommandsAsync(commands);
    }
}
