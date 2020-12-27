using DAL.Entities;
using ExamPreparation.Commands;
using ExamPreparation.ViewModels.StudentViewModels;
using ExamPreparation.ViewModels.TeacherViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamPreparation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ExamDbContext db;

        private User CurrentUser { get; set; }

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            db = new ExamDbContext();
            setLoginViewModel(new LoginViewModel(db));
        }

        private void setLoginViewModel(LoginViewModel loginViewModel)
        {
            loginViewModel.UserLogged += LoginViewModel_UserLogged;
            CurrentViewModel = loginViewModel;
        }

        private void LoginViewModel_UserLogged(object sender, EventArgs e)
        {
            if (sender is LoginViewModel)
                CurrentUser = (sender as LoginViewModel).CurrentUser;

            if (CurrentUser.UserType.Type == "Student")
                CurrentViewModel = new StudentViewModel(CurrentUser.Student, db);
            else
                CurrentViewModel = new TeacherViewModel(CurrentUser.Teacher, db);
        }
    }
}
