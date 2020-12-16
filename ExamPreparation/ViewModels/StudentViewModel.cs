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
            CurrentStudyingVM = new TasksViewModel(1, ShowThemes, ShowTheory);
            //CurrentStudyingVM = new ThemesViewModel(ShowTheory, ShowTasks);
        }

        private void ShowThemes()
        {
            CurrentStudyingVM = new ThemesViewModel(ShowTheory, ShowTasks);
        }

        private void ShowTheory(object obj)
        {
            CurrentStudyingVM = new TheoryViewModel(Convert.ToInt32(obj), ShowThemes, ShowTasks);
        }


        private void ShowTasks(object obj)
        {
            CurrentStudyingVM = new TasksViewModel(Convert.ToInt32(obj), ShowThemes, ShowTheory);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
