using DAL.Entities;
using DAL.Repositories;
using ExamPreparation.Commands;
using ExamPreparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ExamPreparation.ViewModels.StudentViewModels
{
    public class TasksViewModel : ViewModelBase
    {
        UnitOfWork unitOfWork;

        public int TopicId { get; set; }

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

        public TasksViewModel(UnitOfWork unitOfWork, int TopicId, Action showThemes, Action<object> showTheory)
        {
            this.unitOfWork = unitOfWork;

            this.TopicId = TopicId;

            var tasks = unitOfWork.Tasks.GetList().Where(t => t.TopicId == TopicId);

            Tasks = new List<TaskModel>();
            if (tasks != null)
                foreach (Task t in tasks)
                    Tasks.Add(new TaskModel(t));

            this.showTopics = showThemes;
            this.showTheory = showTheory;
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
