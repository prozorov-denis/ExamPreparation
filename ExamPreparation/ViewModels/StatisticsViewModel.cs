using DAL.Entities;
using ExamPreparation.Commands;
using ExamPreparation.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ExamPreparation.ViewModels
{
    public class StatisticsViewModel : ViewModelBase
    {
        ExamDbContext db;

        Student CurrentStudent;

        public bool IsTeacherCurrent { get; set; }

        Action showStudents;

        public List<StatisticsModel> Statistics { get; set; }

        private bool hasStartDate;
        public bool HasStartDate
        {
            get { return hasStartDate; }
            set
            {
                hasStartDate = value;
                CheckDates();
                OnPropertyChanged();
            }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                CheckDates();
                OnPropertyChanged();
            }
        }

        private bool hasEndDate;
        public bool HasEndDate
        {
            get { return hasEndDate; }
            set
            {
                hasEndDate = value;
                CheckDates();
                OnPropertyChanged();
            }
        }

        public DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                endDate.AddHours(23);
                endDate.AddMinutes(59);
                endDate.AddSeconds(59);
                endDate.AddMilliseconds(999);
                CheckDates();
                OnPropertyChanged();
            }
        }

        private bool areDatesValid;
        public bool AreDatesValid
        {
            get { return areDatesValid; }
            set
            {
                areDatesValid = value;
                OnPropertyChanged();
            }
        }

        private bool hasStatistics;
        public bool HasStatistics
        {
            get { return hasStatistics; }
            set
            {
                hasStatistics = value;
                OnPropertyChanged();
            }
        }

        public StatisticsViewModel(Student student, ExamDbContext db)
        {
            startDate = DateTime.Today;
            endDate = DateTime.Today;
            HasStartDate = true;
            HasEndDate = true;
            AreDatesValid = true;

            this.db = db;
            CurrentStudent = student;
        }

        public StatisticsViewModel(Student student, ExamDbContext db, bool IsTeacherCurrent, Action ShowStudents)
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            HasStartDate = true;
            HasEndDate = true;
            AreDatesValid = true;

            this.db = db;
            CurrentStudent = student;
            this.IsTeacherCurrent = IsTeacherCurrent;
            showStudents = ShowStudents;
        }

        private void CheckDates()
        {
            AreDatesValid = true;

            if (HasStartDate && HasEndDate)
                if (startDate > endDate)
                    AreDatesValid = false;

            if (HasStartDate)
                if (StartDate > DateTime.Now)
                    AreDatesValid = false;

            if (HasEndDate)
                if (EndDate > DateTime.Now)
                    AreDatesValid = false;
        }

        private StatisticsModel FormTopicStatistics(Topic topic, Student student, DateTime StartDate, bool HasStartDate, DateTime EndDate, bool HasEndDate)
        {

            List<TaskResult> taskResults;
            taskResults = student.TaskResult.Where(tr => tr.Task.TopicId == topic.TopicId).ToList();

            if (HasStartDate && StartDate != null)
                taskResults = taskResults.Where(tr => tr.Date >= StartDate).ToList();

            if (HasEndDate && EndDate != null)
                taskResults = taskResults.Where(tr => tr.Date <= EndDate).ToList();

            int N1 = taskResults.Count();
            int N2 = taskResults.Where(tr => tr.IsSolved).Count();
            string statisticsTitle = topic.Title + ": " + N2 + " из " + N1;

            StatisticsModel statistics = new StatisticsModel(statisticsTitle);

            List<Task> tasks;
            tasks = topic.Task.ToList();
            foreach (Task t in tasks)
            {
                int n1 = 0;
                n1 = taskResults.Where(tr => tr.TaskId == t.TaskId).Count();

                int n2 = 0;
                n2 = taskResults.Where(tr => tr.TaskId == t.TaskId && tr.IsSolved).Count();

                statistics.Statistics.Add(new StatisticsModel("Задание " + t.TaskId + ": " + n2 + " из " + n1));
            }

            return statistics;
        }

        public ICommand ShowStatisticsCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (AreDatesValid)
                    {
                        Statistics = new List<StatisticsModel>();

                        var topics = db.Topic.ToList();

                        if (topics != null)
                            foreach (Topic t in topics)
                                Statistics.Add(FormTopicStatistics(t, CurrentStudent, StartDate, HasStartDate, EndDate, HasEndDate));

                        if (Statistics.Count > 0)
                        {
                            HasStatistics = true;
                            OnPropertyChanged("Statistics");
                        }                   
                        else
                            HasStatistics = false;
                    }
                });
            }
        }

        public ICommand GeneratePdfCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (HasStatistics)
                    {
                        try
                        {
                            Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "Pdf file (*.pdf)|*.pdf";
                            if (saveFileDialog.ShowDialog() == true)
                                PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));

                            document.Open();
                            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                            document.Add(new Paragraph(CurrentStudent.User.Surname + " " + CurrentStudent.User.Name + " " + CurrentStudent.User.Patronymic, font));

                            string tasksString = "Выполненные задания";
                            if (HasStartDate)
                                tasksString += " с " + StartDate.Day + "." + StartDate.Month + "." + StartDate.Year;
                            if (HasEndDate)
                                tasksString += " по " + EndDate.Day + "." + EndDate.Month + "." + EndDate.Year;
                            document.Add(new Paragraph(tasksString, font));

                            document.Add(new Paragraph("\n"));
                            foreach (StatisticsModel topic in Statistics)
                            {
                                string topicString = topic.Title;
                                document.Add(new Paragraph(topicString, font));
                                foreach (StatisticsModel task in topic.Statistics)
                                    document.Add(new Paragraph(task.Title, font));
                                document.Add(new Paragraph("\n"));
                            }

                            document.Close();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("При сохранении файла произошла ошибка. " + ex.Message);
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
                    showStudents.Invoke();
                });
            }
        }
    }
}
