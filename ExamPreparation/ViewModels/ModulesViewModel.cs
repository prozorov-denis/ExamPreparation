using ExamPreparation.Commands;
using ExamPreparation.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamPreparation.ViewModels
{
    public class ModulesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ModuleModel> Modules { get; set; }

        public ModulesViewModel() : base()
        {
            
            Modules = new ObservableCollection<ModuleModel>();
            for (int i = 0; i < 10; i++)
                Modules.Add(new ModuleModel { Title = "Title " + i, Theme = "Theme " + i, IsTheoryAvailable = true, AreProblemsAvailable = true, IsTestAvailable = true });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ShowTheory
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    
                });
            }
        }
    }
}
