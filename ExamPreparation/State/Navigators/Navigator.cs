using ExamPreparation.Commands;
using ExamPreparation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamPreparation.State.Navigators
{
    public class Navigator : INavigator
    {
        public ViewModelBase CurrentViewModel { get ; set; }

        public ICommand UpdateCurrentViewModeCommand => new UpdateCurrentViewModelCommand(this);
    }
}
