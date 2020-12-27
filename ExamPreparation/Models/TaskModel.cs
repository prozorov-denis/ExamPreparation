using DAL.Entities;
using ExamPreparation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Packaging;

namespace ExamPreparation.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        public int TaskId { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; }
        public string TaskText { get; set; }
        public BitmapImage TaskImage { get; set; }
        public string Answer { get; set; }
        public string SolutionText { get; set; }
        public BitmapImage SolutionImage { get; set; }
        public string StudentAnswer { get; set; }
        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }
        private bool isDone;
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                isDone = value;
                OnPropertyChanged();
            }
        }
        private bool solutionVisability;
        public bool SolutionVisability
        {
            get { return solutionVisability; }
            set
            {
                solutionVisability = value;
                OnPropertyChanged();
                if (solutionVisability == true)
                    SolutionCommand = "Скрыть решение";
                else
                    SolutionCommand = "Показать решение";
            }
        }
        private string solutionCommand;
        public string SolutionCommand
        {
            get { return solutionCommand; }
            set
            {
                solutionCommand = value;
                OnPropertyChanged();
            }
        }

        public TaskModel(Task task) 
        {
            TaskId = task.TaskId;

            TopicId = task.TopicId;

            Title = "Задание " + TaskId;

            TaskText = task.TaskText;
            if (task.TaskImage != null)
                TaskImage = ConvertByteArrayToBitmapImage(task.TaskImage);
            else
                TaskImage = null;

            Answer = task.Answer;

            SolutionText = task.SolutionText;
            if (task.SolutionImage != null)
                SolutionImage = ConvertByteArrayToBitmapImage(task.SolutionImage);
            else
                SolutionImage = null;

            isDone = false;

            solutionVisability = false;
            solutionCommand = "Показать решение";

            StudentAnswer = null;
        }

        private BitmapImage ConvertByteArrayToBitmapImage(Byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
