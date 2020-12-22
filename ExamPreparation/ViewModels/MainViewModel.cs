using DAL.Entities;
using DAL.Repositories;
using ExamPreparation.Commands;
using ExamPreparation.ViewModels.StudentViewModels;
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
        private UnitOfWork unitOfWork;

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
            unitOfWork = new UnitOfWork();
            setLoginViewModel(new LoginViewModel(unitOfWork));
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

            CurrentViewModel = new StudentViewModel(CurrentUser.Student, unitOfWork);
        }
    }
}
