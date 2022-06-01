using System.Collections.Generic;

namespace TelegramBot.Models
{
    public class Ticket
    {
        public string TicketName { get; set; }
        public List<QuestionModel> QuestionModels { get; set; }
        
        public Ticket(string name)
        {
            TicketName = name;
        }
    }
}
