using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.Models
{
    public class MessageModel
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public int MessageId { get; set; }

        public MessageModel(Message message, int CurrentUserTypeId)
        {
            MessageId = message.MessageId;

            if (message.UserTypeId == CurrentUserTypeId)
                SenderName = "Вы";
            else
            if (message.UserTypeId == 1)
                SenderName = message.Student.User.Surname + " " + message.Student.User.Name + " " + message.Student.User.Patronymic;
            else
                SenderName = message.Teacher.User.Surname + " " + message.Teacher.User.Name + " " + message.Teacher.User.Patronymic;

            Text = message.Text;

            Date = message.Date.ToString();
        }
    }
}
