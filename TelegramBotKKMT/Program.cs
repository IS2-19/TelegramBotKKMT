using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace TelegramBotKKMT;

internal class Program
{
    private const string token = "5788996324:AAG9T9WxU6BLCjjE9Ozyi3K43Pd57Yx2Nk4";
    private static readonly ITelegramBotClient client = new TelegramBotClient(token);
    static void Main(string[] args)
    {
        Console.WriteLine("> Start");
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }, // receive all update types
        };
        client.StartReceiving(
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
        
        //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
        if (update.Type is Telegram.Bot.Types.Enums.UpdateType.Message)
        {
            if (update.Message?.Text is not null)
            {
                Console.WriteLine($"> New Message: \"{update.Message.Text}\"");
            }
            
        }
        /*if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
        {
            
            var message = update.Message;
            if (message.Text.ToLower() == "ff")
            {
                await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                return;
            }
            await botClient.SendTextMessageAsync(message.Chat, "Стандартный ответ, комманда не распознана.");
        }*/
    }

    public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        // Некоторые действия
        Console.WriteLine("> Error handled");
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
    }
}
