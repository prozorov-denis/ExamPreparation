using DAL.Entities;
using ExamPreparation.Commands;
using ExamPreparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace ExamPreparation.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        ExamDbContext db;

        public User CurrentUser { get; set; }

        public User Companion { get; set; }

        List<MessageModel> messages;
        public List<MessageModel> Messages
        {
            get { return messages; }
            set
            {
                messages = value;
                OnPropertyChanged();
            }
        }

        public bool CanSend => CurrentText.Length > 0;

        private string currentText;
        public string CurrentText
        {
            get { return currentText; }
            set
            {
                currentText = value;
                OnPropertyChanged();
            }
        }

        Timer checkChangesTimer;
        DateTime lastCheck;

        Action teacherShowStudents;
        public bool IsTeacherCurrent => CurrentUser.UserType.Type == "Teacher";

        public ChatViewModel(ExamDbContext db, User CurrentUser, User Companion)
        {
            this.db = db;

            this.CurrentUser = CurrentUser;
            this.Companion = Companion;

            Messages = new List<MessageModel>();
            List<Message> newmessages;

            try
            {
                if (CurrentUser.UserType.Type == "Student")
                    newmessages = db.Message.Where(m => m.StudentId == this.CurrentUser.Student.StudentId && m.TeacherId == this.Companion.Teacher.TeacherId).ToList();
                else
                    newmessages = db.Message.Where(m => m.TeacherId == this.CurrentUser.Teacher.TeacherId && m.StudentId == this.Companion.Student.StudentId).ToList();

                if (newmessages != null)
                {
                    foreach (Message m in newmessages)
                        Messages.Add(new MessageModel(m, this.CurrentUser.UserTypeId));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("При загрезке сообщений произошла ошибка! " + ex.Message);
            }


            teacherShowStudents = null;

            lastCheck = DateTime.Now;
            checkChangesTimer = new Timer(1000);
            checkChangesTimer.Elapsed += CheckChangesTimer_Elapsed;
            checkChangesTimer.Start();
        }

        private void CheckChangesTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            loadMessages();
            lastCheck = lastCheck.AddMilliseconds(checkChangesTimer.Interval);
        }

        public ChatViewModel(ExamDbContext db, User CurrentUser, User Companion, Action TeacherShowStudents)
        {
            this.db = db;

            this.CurrentUser = CurrentUser;
            this.Companion = Companion;

            Messages = new List<MessageModel>();
            List<Message> newmessages;

            if (CurrentUser.UserType.Type == "Student")
                newmessages = db.Message.Where(m => m.StudentId == this.CurrentUser.Student.StudentId && m.TeacherId == this.Companion.Teacher.TeacherId).ToList();
            else
                newmessages = db.Message.Where(m => m.TeacherId == this.CurrentUser.Teacher.TeacherId && m.StudentId == this.Companion.Student.StudentId).ToList();

            if (newmessages != null)
            {
                foreach (Message m in newmessages)
                    Messages.Add(new MessageModel(m, this.CurrentUser.UserTypeId));
            }

            teacherShowStudents = TeacherShowStudents;

            lastCheck = DateTime.Now;
            checkChangesTimer = new Timer(1000);
            checkChangesTimer.Elapsed += CheckChangesTimer_Elapsed;
            checkChangesTimer.Start();
        }

        private void loadMessages()
        {
            try
            {
                List<Message> newmessages;

                if (CurrentUser.UserType.Type == "Student")
                    newmessages = db.Message.Where(m => m.StudentId == this.CurrentUser.Student.StudentId && m.TeacherId == this.Companion.Teacher.TeacherId).ToList();
                else
                    newmessages = db.Message.Where(m => m.TeacherId == this.CurrentUser.Teacher.TeacherId && m.StudentId == this.Companion.Student.StudentId).ToList();

                if (Messages.Count > 0)
                    newmessages = newmessages.Where(m => m.MessageId > Messages.Last().MessageId).ToList();

                if (newmessages != null)
                {
                    foreach (Message m in newmessages)
                        Messages.Add(new MessageModel(m, this.CurrentUser.UserTypeId));
                }
                Messages = Messages.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При загрезке сообщений произошла ошибка! " + ex.Message);
            }
        }


        public ICommand SendMessageCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (CanSend)
                    {
                        try
                        {
                            Message m = new Message();
                            m.Date = DateTime.Now;
                            m.Text = CurrentText;
                            if (CurrentUser.UserType.Type == "Student")
                            {
                                m.StudentId = CurrentUser.Student.StudentId;
                                m.TeacherId = Companion.Teacher.TeacherId;
                            }
                            else
                            {
                                m.StudentId = Companion.Student.StudentId;
                                m.TeacherId = CurrentUser.Teacher.TeacherId;
                            }
                            m.UserTypeId = CurrentUser.UserTypeId;

                            List<Message> messages;
                            if (CurrentUser.UserType.Type == "Student")
                                messages = db.Message.Where(mes => mes.StudentId == this.CurrentUser.Student.StudentId && mes.TeacherId == this.Companion.Teacher.TeacherId).ToList();
                            else
                                messages = db.Message.Where(mes => mes.TeacherId == this.CurrentUser.Teacher.TeacherId && mes.StudentId == this.Companion.Student.StudentId).ToList();

                            if (messages.Count > 0)
                                m.MessageId = messages.Last().MessageId + 1;
                            else
                                m.MessageId = 1;

                            db.Message.Add(m);
                            db.SaveChanges();
                            CurrentText = "";
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Ваше сообщение не было доставлено. " + ex.Message);
                        }
                    }
                });
            }
        }

        public ICommand ShowStudentsCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (teacherShowStudents != null)
                    {
                        checkChangesTimer.Stop();
                        teacherShowStudents.Invoke();
                    }    
                });
            }
        }
    }
}
