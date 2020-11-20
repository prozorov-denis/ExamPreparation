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
        public ObservableCollection<ThemeModel> Themes { get; set; }

        private Action<object> showTheory;

        public ThemesViewModel(Action<object> showTheory) : base()
        {

            Themes = new ObservableCollection<ThemeModel>();
            for (int i = 0; i < 10; i++)
                Themes.Add(new ThemeModel { Theme_Id = i, Title = "Title " + i, Theme = "Theme " + i, IsTheoryAvailable = true, AreProblemsAvailable = true, IsTestAvailable = true });
            this.showTheory = showTheory;
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
                    MessageBox.Show("Задания " + obj.ToString());
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
