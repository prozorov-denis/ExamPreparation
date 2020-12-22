using DAL.Entities;
using DAL.Repositories;
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
        private UnitOfWork unitOfWork;

        public List<Topic> Topics { get; set; }

        private Action<object> showTheory;
        private Action<object> showTasks;


        public TopicsViewModel(UnitOfWork unitOfWork, Action<object> showTheory, Action<object> showTasks) : base()
        {
            this.unitOfWork = unitOfWork;
            this.showTheory = showTheory;
            this.showTasks = showTasks;

            Topics = unitOfWork.Topics.GetList();
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
