using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Models
{
    public class QuestionModel
    {
        public string QuestionName { get; set; }
        public string CorrectAnswer { get; set; }

        public List<Answer> TicketAnswers { get; set; }

    }
}
