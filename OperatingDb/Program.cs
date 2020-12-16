using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingDb
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork uof = new UnitOfWork();

            Task task = new Task();
            task.TaskId = 1;
            task.TopicId = 1;
            string pdfFilePath = @"C:\Users\mrpro\Desktop\CourseWork\Tasks\1\" + 1 + ".xps";
            task.Text = System.IO.File.ReadAllBytes(pdfFilePath);
            task.Answer = "answer1";
            uof.Tasks.Create(task);
            uof.Save();
            //for (int i = 1; i <= 5; ++i)
            //{
            //    Task task = new Task();
            //    task.TaskId = i;
            //    task.TopicId = 1;
            //    string pdfFilePath = @"C:\Users\mrpro\Desktop\CourseWork\Tasks\1\" + i + ".pdf";
            //    task.Text = System.IO.File.ReadAllBytes(pdfFilePath);
            //}
        }
    }
}
