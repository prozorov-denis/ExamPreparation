using ExamPreparation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamPreparation.State.Navigators
{
    public enum ViewType
    {
        Account,
        Plan,
        Modules,
        Massages,
        Settings
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModeCommand { get; }
    }
}
