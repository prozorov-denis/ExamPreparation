using ExamPreparation.State.Navigators;
using ExamPreparation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamPreparation.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Account:
                        _navigator.CurrentViewModel = new AccountViewModel();
                        break;
                    case ViewType.Plan:
                        _navigator.CurrentViewModel = new PlanViewModel();
                        break;
                    case ViewType.Modules:
                        _navigator.CurrentViewModel = new ModulesViewModel();
                        break;
                    case ViewType.Massages:
                        _navigator.CurrentViewModel = new MassagesViewModel();
                        break;
                    case ViewType.Settings:
                        _navigator.CurrentViewModel = new SettingsViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}