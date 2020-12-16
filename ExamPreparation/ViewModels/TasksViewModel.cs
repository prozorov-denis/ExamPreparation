using DAL.Entities;
using DAL.Repositories;
using ExamPreparation.Commands;
using ExamPreparation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ExamPreparation.ViewModels
{
    class TasksViewModel : INotifyPropertyChanged
    {
        UnitOfWork uof;

        public int ThemeId { get; set; }

        public List<TaskModel> Tasks { get; set; }

        private bool isTestAvailable;
        public bool IsTestAvailable
        {
            get { return isTestAvailable; }
            set
            {
                isTestAvailable = value;
                NotifyPropertyChanged("IsTestAvailable");
            }
        }

        private Action showThemes;
        private Action<object> showTheory;

        public TasksViewModel()
        {
            ThemeId = 0;

            Tasks = new List<TaskModel>();

            IsTestAvailable = false;

            //for (int i = 0; i < 10; i++)
            //    Tasks.Add(new TaskModel());

            this.showThemes = null;
            this.showTheory = null;
        }

        public TasksViewModel(int themeId, Action showThemes, Action<object> showTheory)
        {
            ThemeId = themeId;

            uof = new UnitOfWork();
            List<Task> tasks = uof.Tasks.GetList();

            Tasks = new List<TaskModel>();
            foreach(Task t in tasks)
                Tasks.Add(new TaskModel(t));

            IsTestAvailable = false;

            this.showThemes = showThemes;
            this.showTheory = showTheory;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public ICommand ShowThemesCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    showThemes.Invoke();
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
