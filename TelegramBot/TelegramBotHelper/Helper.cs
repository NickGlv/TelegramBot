using System;

namespace TelegramBotHelper
{
    public class Helper
    {
        public static string GetTypeOfMessage(string message)
        {
            switch (message)
            {
                case "Білети":
                    return "/tickets";
                case "Про бота":
                    return "/about-us";
                case "Завершити":
                    return "/close";
                default:
                    return "/start";
            }
        }
    }
}
