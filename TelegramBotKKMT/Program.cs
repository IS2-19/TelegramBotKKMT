using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace TelegramBotKKMT;

internal class Program
{
    private static ITelegramBotClient bot = new TelegramBotClient("5788996324:AAG9T9WxU6BLCjjE9Ozyi3K43Pd57Yx2Nk4");
    static void Main(string[] args)
    {
        Console.WriteLine("> Start");
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }, // receive all update types
        };
        bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
        Console.Read();
        Console.WriteLine("> Stop");
    }

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Некоторые действия
        Console.WriteLine("> New Message");
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
        if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
        {
            var message = update.Message;
            if (update.Message as Message is not null)
            {
                if (update.Message.Text?.ToLower() == "ff")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                    return;
                }
            }
            
            await botClient.SendTextMessageAsync(message.Chat, "Стандартный ответ, комманда не распознана.");
        }
    }

    public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        // Некоторые действия
        Console.WriteLine("> Error handled");
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
    }
}
