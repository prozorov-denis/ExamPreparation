using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OperatingDb
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork uof = new UnitOfWork();
            
            //int k = 1;
            //for (int i = 1; i <= 10; ++i)
            //{
            //    for (int j = 1; j <= 5; j++)
            //    {
            //        Task task = new Task();
            //        task.TaskId = k;
            //        task.TopicId = i;
            //        string files = @"C:\Users\mrpro\Desktop\CourseWork\Tasks\" + i + "\\";
            //        string taskText = j + ".txt";
            //        string taskImage = j + ".png";
            //        string solutionText = j + "S.txt";
            //        string solutionImage = j + "S.png";

            //        using (StreamReader sr = new StreamReader(files + taskText))
            //        {
            //            task.TaskText = sr.ReadToEnd();
            //        }

            //        if (File.Exists(files + taskImage))
            //            task.TaskImage = File.ReadAllBytes(files + taskImage);

            //        using (StreamReader sr = new StreamReader(files + solutionText))
            //        {
            //            task.SolutionText = sr.ReadToEnd();
            //        }

            //        if (File.Exists(files + solutionImage))
            //            task.SolutionImage = File.ReadAllBytes(files + solutionImage);

            //        uof.Tasks.Create(task);
            //        k++;
            //    }  
            //}

            for (int i = 1; i <= 10; ++i)
            {
                Topic topic = uof.Topics.GetItem(i);
                string pdfFilePath = @"C:\Users\mrpro\Desktop\CourseWork\Theory\" + i + ".xps";
                topic.Theory = System.IO.File.ReadAllBytes(pdfFilePath);
                uof.Topics.Update(topic);
            }
            uof.Save();
        }
    }
}
