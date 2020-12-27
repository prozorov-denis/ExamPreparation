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
    public class TopicsViewModel : ViewModelBase
    {
        private ExamDbContext db;

        public List<Topic> Topics { get; set; }

        private Action<object> showTheory;
        private Action<object> showTasks;


        public TopicsViewModel(ExamDbContext db, Action<object> showTheory, Action<object> showTasks) : base()
        {
            this.db = db;
            this.showTheory = showTheory;
            this.showTasks = showTasks;

            try
            {
                Topics = db.Topic.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("При загрузке данных проихошла ошибка. " + ex.Message);
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

        public ICommand ShowTasksCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    showTasks.Invoke(obj);
                });
            }
        }
    }
}
