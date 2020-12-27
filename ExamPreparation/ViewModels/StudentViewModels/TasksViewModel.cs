using DAL.Entities;
using ExamPreparation.Commands;
using ExamPreparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ExamPreparation.ViewModels.StudentViewModels
{
    public class TasksViewModel : ViewModelBase
    {
        ExamDbContext db;

        public int TopicId { get; set; }

        public int StudentId { get; set; }

        public List<TaskModel> Tasks { get; set; }

        private Action showTopics;
        private Action<object> showTheory;

        public TasksViewModel()
        {
            Tasks = new List<TaskModel>();

            //for (int i = 0; i < 10; i++)
            //    Tasks.Add(new TaskModel());

            this.showTopics = null;
            this.showTheory = null;
        }

        public TasksViewModel(ExamDbContext db, int TopicId, int StudentId, Action showThemes, Action<object> showTheory)
        {
            this.db = db;

            this.TopicId = TopicId;

            this.StudentId = StudentId;

            try
            {
                var tasks = db.Task.ToList().Where(t => t.TopicId == TopicId);
                Tasks = new List<TaskModel>();
                if (tasks != null)
                    foreach (Task t in tasks)
                        if (t.TaskResult.Count > 0)
                        {
                            if (t.TaskResult.Last().IsSolved)
                                Tasks.Add(new TaskModel(t));
                        }
                        else
                            Tasks.Add(new TaskModel(t));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удалось загрузить задания. " + ex.Message);
            }

            this.showTopics = showThemes;
            this.showTheory = showTheory;
        }

        private void CheckAnswer(TaskModel CurrentTask)
        {
            if (CurrentTask != null)
            {
                try
                {
                    TaskResult taskResult = new TaskResult();

                    TaskResult lastTaskResult = db.TaskResult.ToList().LastOrDefault();
                    if (lastTaskResult != null)
                        taskResult.TaskResultId = lastTaskResult.TaskResultId + 1;
                    else
                        taskResult.TaskResultId = 1;
                    taskResult.Date = DateTime.Now;
                    taskResult.TaskId = CurrentTask.TaskId;
                    taskResult.StudentId = StudentId;
                    if (CurrentTask.StudentAnswer == CurrentTask.Answer)
                        taskResult.IsSolved = true;
                    else
                        taskResult.IsSolved = false;

                    db.TaskResult.Add(taskResult);
                    db.SaveChanges();

                    CurrentTask.IsDone = true;
                    if (taskResult.IsSolved)
                    {
                        CurrentTask.Result = "Задание решено правильно!";
                        Tasks.Remove(CurrentTask);
                        Tasks = Tasks.ToList();
                        OnPropertyChanged("Tasks");
                    }
                    else
                        CurrentTask.Result = "Задание решено не правильно!";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Не удалось сохранить результат! " + ex.Message);
                }
            }
        }

        public ICommand CheckAnswerCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    TaskModel currentTask = Tasks.Where(t => t.TaskId == Convert.ToInt32(obj)).LastOrDefault();
                    CheckAnswer(currentTask);
                });
            }
        }

        public ICommand ChangeSolutionVisabilityCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    TaskModel currentTask = Tasks.Where(t => t.TaskId == Convert.ToInt32(obj)).LastOrDefault();
                    currentTask.SolutionVisability = !currentTask.SolutionVisability;
                });
            }
        }

        public ICommand ShowAllTasksCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                    var tasks = db.Task.ToList().Where(t => t.TopicId == TopicId);

                    Tasks = new List<TaskModel>();
                    if (tasks != null)
                        foreach (Task t in tasks)
                            Tasks.Add(new TaskModel(t));

                    OnPropertyChanged("Tasks");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Не удалось отобразить задания. " + ex.Message);
                    }
                });  
            }
        }

        public ICommand ShowTopicsCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    showTopics.Invoke();
                });
            }
        }

        public ICommand ShowTheoryCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    showTheory.Invoke(obj);
                });
            }
        }
    }
}
