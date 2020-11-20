using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private object currentStudyingVM;
        public object CurrentStudyingVM
        {
            get { return currentStudyingVM; }
            set
            {
                currentStudyingVM = value;
                OnPropertyChanged("CurrentStudyingVM");
            }
        }

        public StudentViewModel()
        {
            CurrentStudyingVM = new ThemesViewModel(ShowTheory);
        }

        private void ShowTheory(object obj)
        {
            CurrentStudyingVM = new TheoryViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
