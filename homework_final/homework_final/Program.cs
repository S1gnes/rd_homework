using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Game = homework_final.Game;

class Program
{
    private static Dictionary<long, Game> ActiveGames = new Dictionary<long, Game>();
    private static string Token = "6885930210:AAG2Nrt0c5x6JKuZuMEVtwbdLTh0V6TctcI";
    static ITelegramBotClient BotClient;
    static CancellationTokenSource cts = new();

   
    static ReceiverOptions receiverOptions = new()
    {
        AllowedUpdates = Array.Empty<UpdateType>() 
    };

    static void Main()
    {
        BotClient = new TelegramBotClient(Token);

        var me = BotClient.GetMeAsync().Result;
        Console.WriteLine($"Logged in as {me.Username}");

        BotClient.StartReceiving(
            updateHandler: Bot_OnUpdate,
            pollingErrorHandler: Bot_HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        Console.WriteLine("Press any key to shutdown");
        Console.ReadKey();
    }

    static async Task Bot_OnUpdate(object sender, Update update, CancellationToken cancellationToken)
    {
        
        if (update.Message is not { } message)
            return;
        
        if (message.Text is not { } messageText)
            return;

        var chatId = message.Chat.Id;
        Console.WriteLine($"{chatId} | {messageText}");

        if (messageText.Equals("/newgame"))
        {
            Game NewGame = new Game();
            ActiveGames[chatId] = NewGame;
            Message sentMessage = await BotClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Input dealer card.");
            return;
        } else {
            Game CurrentGame;
            ActiveGames.TryGetValue(chatId, out CurrentGame);
            if (CurrentGame != null)
            {
                if (CurrentGame.state == homework_final.CurrentState.WaitingForDealer || CurrentGame.state == homework_final.CurrentState.WaitingForUserFirstCard || CurrentGame.state == homework_final.CurrentState.WaitingForUserCard)
                {
                    if (int.TryParse(messageText, out int result))
                    {
                        switch(CurrentGame.state)
                        {
                            case homework_final.CurrentState.WaitingForDealer:
                            {
                                CurrentGame.SetDealerCard(result);
                                Message sentMessage = await BotClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: "Input first user card.");
                                return;
                            }
                            case homework_final.CurrentState.WaitingForUserFirstCard:
                            {
                                CurrentGame.AddPlayerCard(result);

                                Message sentMessage = await BotClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: "Input user card.");
                                return;
                            }
                            case homework_final.CurrentState.WaitingForUserCard:
                            {
                                CurrentGame.AddPlayerCard(result);

                                string bestMove = CurrentGame.DetermineBestMove();

                                await BotClient.SendTextMessageAsync(chatId: chatId, text: bestMove);

                                if (bestMove == "Взять еще карту")
                                {
                                    Console.WriteLine("TAKE");
                                }
                                else
                                {
                                    await BotClient.SendTextMessageAsync(chatId: chatId, text: "Game ended");
                                    CurrentGame.state = homework_final.CurrentState.Ended;
                                    Console.WriteLine("ENDED");
                                }
                                return;
                            }

                            default: break;
                        }
                    }
                    else
                    {
                        Message sentMessage = await BotClient.SendTextMessageAsync(
                            chatId: chatId,
                            text: "Please, input a number, representing a card");
                    }
                }

            }
        }
    }

    static Task Bot_HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}
