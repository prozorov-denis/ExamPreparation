using ExamPreparation.Models;
using ExamPreparation.UserControls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.ViewModels
{
    public class ModulesViewModel : ViewModelBase
    {
        public ObservableCollection<ModuleModel> Modules { get; set; }

        public ModulesViewModel() : base()
        {
            Modules = new ObservableCollection<ModuleModel>();
            for (int i = 0; i < 10; i++)
                Modules.Add(new ModuleModel { Title = "Title " + i, Theme = "Theme " + i, IsTheoryAvailable = true, AreProblemsAvailable = true, IsTestAvailable = true });
        }
    }
}
