using DAL.Entities;
using ExamPreparation.Commands;
using ExamPreparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ExamPreparation.ViewModels.StudentViewModels
{
    public class PlanViewModel : ViewModelBase
    {
        ExamDbContext db;

        Student CurrentStudent;

        DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                if (examDate < startDate)
                {
                    examDate = startDate.AddDays(1);
                }
                checkCanFormPlan();
                OnPropertyChanged();
            }
        }

        DateTime examDate;
        public DateTime ExamDate
        {
            get { return examDate; }
            set
            {
                examDate = value;
                checkCanFormPlan();
                OnPropertyChanged();
            }
        }

        public bool AreDatesCorrect => ExamDate > StartDate && StartDate >= DateTime.Now.Date;

        private bool hasPlan;
        public bool HasPlan
        {
            get { return hasPlan; }
            set
            {
                hasPlan = value;
                OnPropertyChanged();
            }
        }

        bool testNeeded;
        public bool TestNeeded
        {
            get { return testNeeded; }
            set
            {
                testNeeded = value;
                OnPropertyChanged();
            }
        }

        bool datesNeeded;
        public bool DatesNeeded
        {
            get { return datesNeeded; }
            set
            {
                datesNeeded = value;
                OnPropertyChanged();
            }
        }

        public List<TaskModel> TestTasks { get; set; }

        public List<PlanPointModel> Plan { get; set; }

        bool canFormPlan;
        public bool CanFormPlan
        {
            get { return canFormPlan; }
            set
            {
                canFormPlan = value;
                OnPropertyChanged();
            }
        }

        public PlanViewModel(Student student, ExamDbContext db)
        {
            this.db = db;
            CurrentStudent = student;

            if (db.Studying.Where(s => s.StudentId == CurrentStudent.StudentId).Count() == 0)
                HasPlan = false;
            else
                HasPlan = true;

            CanFormPlan = HasPlan && AreDatesCorrect;

            TestNeeded = !HasPlan;
            DatesNeeded = !HasPlan;

            if (DatesNeeded)
            {
                StartDate = DateTime.Now;
                ExamDate = DateTime.Now.AddDays(1);
            }
            if (TestNeeded)
            {
                TestTasks = new List<TaskModel>();

                Random random = new Random();

                var topics = db.Topic.ToList();

                if (topics != null)
                    foreach (Topic t in topics)
                    {
                        int n = t.Task.Count();

                        if (n > 0)
                        {
                            Task task = new Task();
                            bool p = false;
                            while (!p)
                            {
                                int id = 1;
                                id = random.Next(1, n);
                                task = t.Task.ToList()[id];
                                if (task != null)
                                    p = true;
                            }
                            TestTasks.Add(new TaskModel(task));
                        }
                    }
            }
            else
                FormPlan();
        }

        private void checkCanFormPlan()
        {
            if (HasPlan && AreDatesCorrect)
                CanFormPlan = true;
            else
                CanFormPlan = false;
        }

        private void FormPlan()
        {
            Plan = new List<PlanPointModel>();

            var studying = CurrentStudent.Studying.ToList();

            if (studying != null)
                foreach (Studying s in studying)
                    if (s.ComplationDate.HasValue)
                        Plan.Add(new PlanPointModel(s.Topic.Title, s.ComplationDate.Value));

            HasPlan = true;
            Plan = Plan.ToList();
            OnPropertyChanged("Plan");
        }

        private void FormPlanFromTest()
        {
            if (TestTasks.Count > 0)
            {
                int nfalse = 0;
                int ntopic = 0;

                nfalse = TestTasks.Where(t => t.IsDone == false).Count();
                ntopic = db.Topic.Count();

                double ndays = (ExamDate - StartDate).TotalDays;

                double x = ndays / (2 * nfalse + (ntopic - nfalse));

                DateTime currentDateTime = StartDate;

                foreach (Topic topic in db.Topic.ToList())
                {
                    var studyings = db.Studying.ToList().Where(st => st.StudentId == CurrentStudent.StudentId && st.TopicId == topic.TopicId);
                    Studying studying;

                    if (studyings.Count() > 0)
                    {
                        studying = studyings.Last();
                        db.Studying.Remove(studying);
                    } 
                    else
                    {
                        studying = new Studying();
                    }

                    studying.ComplationDate = currentDateTime;
                    studying.StudentId = CurrentStudent.StudentId;
                    studying.TopicId = topic.TopicId;

                    studyings = db.Studying.ToList();

                    if (studyings.Count() > 0)
                        studying.StudyingId = studyings.Last().StudyingId + 1;
                    else
                        studying.StudyingId = 1;
                    

                    TaskModel taskModel = TestTasks.Where(t => t.TopicId == topic.TopicId).Last();
                    if (taskModel != null)
                        if (taskModel.IsDone == false)
                        {
                            studying.ComplationDate = currentDateTime.AddDays(x * 2);
                            currentDateTime = studying.ComplationDate.Value;
                        }
                        else
                        {
                            studying.ComplationDate = currentDateTime.AddDays(x);
                            currentDateTime = studying.ComplationDate.Value;
                        }
                    else
                    {
                        studying.ComplationDate = currentDateTime.AddDays(x);
                        currentDateTime = studying.ComplationDate.Value;
                    }

                    if (studying.ComplationDate > ExamDate)
                        studying.ComplationDate = ExamDate;

                    db.Studying.Add(studying);
                    db.SaveChanges();
                }
            }
        }

        public ICommand FinishTestCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (TestTasks.Count > 0)
                    {
                        foreach (TaskModel taskModel in TestTasks)
                        {
                            if (taskModel.StudentAnswer == taskModel.Answer)
                                taskModel.IsDone = true;
                            else
                                taskModel.IsDone = false;
                        }

                        TestNeeded = false;
                        HasPlan = true;
                        checkCanFormPlan();
                    }
                });
            }
        }

        public ICommand FormPlanCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (CanFormPlan)
                    {
                        FormPlanFromTest();
                        FormPlan();
                    }     
                    DatesNeeded = false;
                });
            }
        }
    }
}
