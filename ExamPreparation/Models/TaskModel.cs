using DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Xps.Packaging;

namespace ExamPreparation.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string TaskText { get; set; }
        public BitmapImage TaskImage { get; set; }
        public bool HasTaskImage => TaskImage != null;
        public string SolutionText { get; set; }
        public BitmapImage SolutionImage { get; set; }
        public bool HasSolutionImage => SolutionImage != null;
        public bool IsDone { get; set; }

        public TaskModel(Task task)
        {
            TaskId = task.TaskId;

            Title = "Задание " + TaskId;

            TaskText = task.TaskText;
            if (task.TaskImage != null)
                TaskImage = ConvertByteArrayToBitmapImage(task.TaskImage);
            else
                TaskImage = null;

            SolutionText = task.SolutionText;
            if (task.SolutionImage != null)
                SolutionImage = ConvertByteArrayToBitmapImage(task.SolutionImage);
            else
                SolutionImage = null;

            if (task.TaskResult.Count > 0)
            {
                if (task.TaskResult.Last().IsSolved.HasValue)
                    IsDone = task.TaskResult.Last().IsSolved.Value;
                else
                    IsDone = false;
            }
            else
                IsDone = false;
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
    }
}
