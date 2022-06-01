using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models
{
    public class InitialData
    {
        public static Ticket GetTicketNumberOne()
        {
            var ticket = new Ticket("Ticket 1");
            ticket.QuestionModels = new List<QuestionModel>();
            var questionList = new List<QuestionModel>
            {
                new QuestionModel
                {
                    QuestionName = "Які з перелічених вимог є обов'язковими для дороги, позначеної знаком «Автомагістраль»? ",
                    CorrectAnswer = "4. Відповіді, зазначені в пунктах 1 і 3.",
                    TicketAnswers = new List<Answer>
                    {
                        new Answer("1. Відсутність перетинів на одному рівні з іншими дорогами, залізничними або трамвайними коліями, пішохідними чи велосипедними доріжками.", false),
                        new Answer("2. Наявність не менше шести смуг для руху в кожному напрямку.", false),
                        new Answer("3. Наявність розділювальної смуги.", false),
                        new Answer("4. Відповіді, зазначені в пунктах 1 і 3.", true)
                    }
                },
                new QuestionModel
                {
                    QuestionName = "В якому з перелічених випадків водій здійснив вимушену зупинку?",
                    CorrectAnswer = "",
                    TicketAnswers = new List<Answer>
                    {
                       new Answer("1. Зупинився на узбіччі через прокол колеса", true),
                        new Answer("2. Зупинився на смузі руху через засліплення фарами зустрічного автомобіля.", false),
                        new Answer("3. Зупинився, щоб надати допомогу пасажиру.", false),
                        new Answer("4. Відповіді 1,2,3.", false)
                    }
                },
                new QuestionModel
                {
                    QuestionName = "Недостатньою видимістю вважається:",
                    CorrectAnswer = "Видимість дороги в напрямку руху менше 300 м у сутінках, в умовах туману, дощу, снігопаду і т. п.",
                    TicketAnswers = new List<Answer>
                    {
                        new Answer("Обмежена оглядовість менше 300 м.", false),
                        new Answer("Видимість дороги в напрямку руху менше 300 метрів, обмежена поворотом дороги.", false),
                        new Answer("Видимість дороги в напрямку руху менше 300 м у сутінках, в умовах туману, дощу, снігопаду і т. п.", true),
                        new Answer("Небезпечний поворот, небезпечний підйом, небезпечний спуск.", false)
                    }
                },               
                new QuestionModel
                {
                    QuestionName = "Оглядовістю вважається:",
                    CorrectAnswer = "1. Об'єктивна можливість бачити дорожню обстановку з місця водія.",
                    TicketAnswers = new List<Answer>
                    {
                        new Answer("1. Об'єктивна можливість бачити дорожню обстановку з місця водія.", true),
                        new Answer("2. Видимість дороги в напрямку руху, яка обмежена геометричними параметрами дороги.", false),
                        new Answer("3. Сукупність факторів, що характеризуються дорожніми умовами, наявністю перешкод на певній ділянці дороги", false)
                    }
                },
                new QuestionModel
                {
                    QuestionName = "Обмежена оглядовість – це видимість дороги в напрямку руху, яка обмежена:",
                    CorrectAnswer = "5. Відповіді 1, 2.",
                    TicketAnswers = new List<Answer>
                    {
                        new Answer("1. Геометричними параметрами дороги.", false),
                        new Answer("2. Придорожніми інженерними спорудами, насадженнями та іншими об'єктами, а також транспортними засобами.", false),
                        new Answer("3. Погодними явищами, такими як дощ, снігопад, туман і т. д.", false),
                        new Answer("4. Правильно все перелічене вище.", false),
                        new Answer("5. Відповіді 1, 2.",true)
                    }
                },
                new QuestionModel
                {
                    QuestionName = "З якого боку дозволено виконати випередження на проїзній частині?",
                    CorrectAnswer = "З будь-якого боку по суміжній смузі з дотриманням безпечного інтервалу.",
                    TicketAnswers = new List<Answer>
                    {
                        new Answer("Тільки з лівого боку.",false),
                        new Answer("Тільки з правого боку.", false),
                        new Answer("З будь-якого боку по суміжній смузі з дотриманням безпечного інтервалу.",true)
                    }
                },
                new QuestionModel
                {
                    QuestionName = "Які фактори можуть призвести до засліплення водія?",
                    CorrectAnswer = "Світло.",
                    TicketAnswers = new List<Answer>
                    {
                        new Answer("Мокрий сніг.", false),
                        new Answer("Сильна злива.", false),
                        new Answer("Інтенсивний снігопад.", false),
                        new Answer("Світло.", true)
                    }
                },
                new QuestionModel
                {
                    QuestionName = "Автомобільна дорога, вулиця (дорога) — це частина території, в тому числі в населеному пункті, призначена для руху:",
                    CorrectAnswer = "Транспортних засобів і пішоходів.",
                    TicketAnswers = new List<Answer>
                    {
                        new Answer("Тільки вантажних і легкових автомобілів.", false),
                        new Answer("Тільки механічних транспортних засобів.", false),
                        new Answer("Транспортних засобів і пішоходів.", true)
                    }
                },new QuestionModel
                {
                    QuestionName = "Адміністративне затримання особи, яка вчинила адміністративне правопорушення, може тривати не більше ніж:",
                    CorrectAnswer = "Три години",
                    TicketAnswers = new List<Answer>
                    {
                        new Answer("П'ять годин.", false),
                        new Answer("Три години", true),
                        new Answer("Чотири години",false)
                    }
                },
                new QuestionModel
                {
                    QuestionName = "До маршрутних транспортних засобів (транспортних засобів загального користування) належать:",
                    CorrectAnswer = "Автобуси, мікроавтобуси, тролейбуси, трамваї і таксі, що рухаються за встановленими маршрутами та мають певні місця на дорозі для посадки (висадки) пасажирів.",
                    TicketAnswers = new List<Answer>
                    {
                        new Answer("Трамваї, тролейбуси, автобуси, метрополітен.", false),
                        new Answer("Транспортні засоби з кількістю місць для сидіння не менш ніж сімнадцять з місцем водія включно, що рухаються за встановленими маршрутами та мають визначені місця на дорозі для посадки (висадки) пасажирів.",false),
                        new Answer("Автобуси, мікроавтобуси, тролейбуси, трамваї і таксі, що рухаються за встановленими маршрутами та мають певні місця на дорозі для посадки (висадки) пасажирів.",true)                        
                    }
                }
            };

            ticket.QuestionModels.AddRange(questionList);
            return ticket;
        }
    }
}
