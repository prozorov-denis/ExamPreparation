using DAL.Entities;
using DAL.Repositories;
using ExamPreparation.Commands;
using ExamPreparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExamPreparation.ViewModels
{
    public class TheoryViewModel
    {
        public string Title { get; set; }

        public string Theory { get; set; }

        public int Theme_Id { get; set; }

        private Action<object> showThemes;

        EFUnitOfWork unitOfWork;

        public TheoryViewModel(int Theme_Id, Action<object> showThemes) : base()
        {
            unitOfWork = new EFUnitOfWork();

            Topic topic = unitOfWork.Topics.GetItem(Theme_Id);

            this.Theme_Id = Theme_Id;
            Title = topic.Title;
            Theory = topic.Theory_Text;
 
            this.showThemes = showThemes;
        }

        public ICommand ShowThemesCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    showThemes.Invoke(obj);
                });
            }
        }

        public ICommand ShowTasksCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    obj = Theme_Id;
                    MessageBox.Show("Задания " + obj.ToString());
                });
            }
        }
    }
}
