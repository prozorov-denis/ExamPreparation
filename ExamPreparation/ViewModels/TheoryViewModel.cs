using ExamPreparation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamPreparation.ViewModels
{
    public class TheoryViewModel
    {
        public string Title { get; set; }

        public string Theory { get; set; }

        public event EventHandler ShowModules;

        public event EventHandler ShowTasks;

        public TheoryViewModel() : base()
        {
            Title = "Количественная оценка информации";

            for (int i = 0; i < 1000; i++)
                Theory += "Оценка ";
            Theory += ".";
        }

        public ICommand ShowTheoryCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (ShowModules != null)
                        ShowModules(this, new EventArgs());
                });
            }
        }

        public ICommand ShowTasksCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (ShowTasks != null)
                        ShowTasks(this, new EventArgs());
                });
            }
        }
    }
}
