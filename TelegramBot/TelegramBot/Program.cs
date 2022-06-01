using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Models;

namespace TelegramBot
{
    class Program
    {
        static int index = 0;
        static int countOfCorrectAnswers = 0;
        const int MaxCount = 9;
        static ITelegramBotClient bot = new TelegramBotClient("5509590103:AAE8e-_RqSU3EcAF_jNlnYD0XQeZE8MqKe8");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            var keyboard = new ReplyKeyboardMarkup(new List<List<KeyboardButton>> {
                new List<KeyboardButton>
                {
                    new KeyboardButton("Білети"),
                    new KeyboardButton("Про бота"),                    
                },
                new List<KeyboardButton>
                {
                    new KeyboardButton("Завершити")
                }
            });

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = TelegramBotHelper.Helper.GetTypeOfMessage(update.Message.Text);
               if (message.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"Привіт, {update.Message.From.FirstName}! Давай перевірем твої знання ПДР", replyMarkup: keyboard);
                    return;
                }
                else if (message.ToLower() == "/tickets")
                {
                    var inlineKeyboards = new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
                    {
                        new List<InlineKeyboardButton>{new InlineKeyboardButton("Білет №1") { CallbackData = "Ticket", } },
                        new List<InlineKeyboardButton>{new InlineKeyboardButton("Білет №2") { CallbackData = "Ticket", } },
                        new List<InlineKeyboardButton>{new InlineKeyboardButton("Білет №3") { CallbackData = "Ticket", } },
                    });

                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Виберіть білет:", replyMarkup: inlineKeyboards);
                    await bot.DeleteMessageAsync(update.Message.Chat.Id, update.Message.MessageId);
                    return;
                }
                else if (message.ToLower() == "/about-us")
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"Я, { bot.GetMeAsync().Result.FirstName }. Хочу перевірити на скільки добре ти знаєш Правила Дорожнього Руху :)");
                    return;
                }
                else if(message.ToLower() == "/close")
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, "До зустрічі!");
                }
                else
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Помилка! Спробуйте пізніше!");
                }
            }
            else if (update.Type.ToString() == "CallbackQuery")
            {
                var callBackMessage = update.CallbackQuery.Data;
                if(callBackMessage == "Ticket")
                {
                    var ticket = InitialData.GetTicketNumberOne();
                    var question = ticket.QuestionModels.First();
                    var buttons = new List<List<InlineKeyboardButton>>();
                    
                    foreach (var answer in question.TicketAnswers)
                    {
                        buttons.Add(new List<InlineKeyboardButton> { new InlineKeyboardButton(answer.Text) { CallbackData = answer.IsCorrect.ToString() } });
                    }
                    var markup = new InlineKeyboardMarkup(buttons);
                    
                    await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, question.QuestionName, replyMarkup: markup);
                    return;
                }
                else if(callBackMessage == "True")
                {
                    countOfCorrectAnswers++;
                    var ticket = InitialData.GetTicketNumberOne();
                    var question = ticket.QuestionModels[index];
                    var buttons = new List<List<InlineKeyboardButton>>();
                    foreach (var answer in question.TicketAnswers)
                    {
                        buttons.Add(new List<InlineKeyboardButton> { new InlineKeyboardButton(answer.Text) { CallbackData = answer.IsCorrect.ToString() } });
                    }
                    var markup = new InlineKeyboardMarkup(buttons);
                    if (index == MaxCount)
                    {
                        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, $"Ви набрали: {countOfCorrectAnswers}/10");
                        if(countOfCorrectAnswers > MaxCount - 3)
                        {
                            await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Вітаю, Ви склали!");
                            countOfCorrectAnswers = 0;
                            index = 0;                          
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "На жаль, Ви не склали!");
                            countOfCorrectAnswers = 0;
                            index = 0;
                        }
                        await bot.DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);
                    }
                    else
                    {
                        index++;
                        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, question.QuestionName, replyMarkup: markup);
                        await bot.DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);
                    }
                    return;
                }
                else if(callBackMessage == "False")
                {
                    var ticket = InitialData.GetTicketNumberOne();
                    var question = ticket.QuestionModels[index];
                    var buttons = new List<List<InlineKeyboardButton>>();
                    foreach (var answer in question.TicketAnswers)
                    {
                        buttons.Add(new List<InlineKeyboardButton> { new InlineKeyboardButton(answer.Text) { CallbackData = answer.IsCorrect.ToString() } });
                    }
                    var markup = new InlineKeyboardMarkup(buttons);
                    if (index == MaxCount)
                    {
                        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, $"Ви набрали: {countOfCorrectAnswers}/10");
                        if (countOfCorrectAnswers > MaxCount - 3)
                        {
                            await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Вітаю, Ви склали!");
                            countOfCorrectAnswers = 0;
                            index = 0;
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "На жаль, Ви не склали!");
                            countOfCorrectAnswers = 0;
                            index = 0;
                        }
                        await bot.DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);
                    }
                    else {
                        index++;
                        await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, question.QuestionName, replyMarkup: markup);
                        await bot.DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);
                    }
                    return;
                }
            }      
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Bot is running " + bot.GetMeAsync().Result.FirstName);

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
            Console.ReadLine();
        }
    }
}
