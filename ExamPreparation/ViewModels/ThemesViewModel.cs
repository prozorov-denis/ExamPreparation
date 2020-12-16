using ExamPreparation.Commands;
using ExamPreparation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ExamPreparation.ViewModels
{
    public class ThemesViewModel
    {
        public List<ThemeModel> Themes { get; set; }

        private Action<object> showTheory;
        private Action<object> showTasks;

        //EFUnitOfWork unitOfWork;

        public ThemesViewModel(Action<object> showTheory, Action<object> showTasks) : base()
        {
            //unitOfWork = new EFUnitOfWork();

            //var topics = unitOfWork.Topics.GetList();

            //Themes = topics.Select(i => new ThemeModel { Theme_Id = i.Topics_ID, Theme = i.Title }).ToList();
            //foreach (ThemeModel t in Themes)
            //{
            //    t.Title = "Задание " + t.Theme_Id;
            //    t.IsTheoryAvailable = true;
            //    t.AreProblemsAvailable = true;
            //    t.IsTestAvailable = true;
            //}
            
            this.showTheory = showTheory;
            this.showTasks = showTasks;
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

        public ICommand ShowTestCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MessageBox.Show("Тест " + obj.ToString());
                });
            }
        }
    }
}
