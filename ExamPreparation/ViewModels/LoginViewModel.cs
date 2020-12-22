using DAL.Entities;
using DAL.Repositories;
using ExamPreparation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExamPreparation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork;

        public User CurrentUser { get; set; }

        public string UserLogin { get; set; }

        public string UserPassword { get; set; }

        private bool success;
        public bool Success
        {
            get { return success; }
            set
            {
                success = value;
                MessageBox.Show(success.ToString());
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            unitOfWork = new UnitOfWork();
            Success = false;
            CurrentUser = null;
        }

        public LoginViewModel(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            Success = false;
            CurrentUser = null;
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (UserLogin != null && UserPassword != null)
                    {
                        List<User> users = unitOfWork.Users.GetList();

                        User user = users.Where(u => u.Login == UserLogin).FirstOrDefault();

                        if (user != null)
                        {
                            if (user.Password == UserPassword.ToString())
                                Success = true;
                            if (Success)
                            {
                                MessageBox.Show("Вход выполнен.");
                                CurrentUser = user;
                                OnUserLogged();
                            }
                            else
                                MessageBox.Show("Неверный пароль.");
                        }
                        else
                            MessageBox.Show("Пользователь с таким логином не найден.");
                    }
                    else
                        MessageBox.Show("Введите логин и пароль.");
                });
            }
        }

        public event EventHandler UserLogged;

        private void OnUserLogged()
        {
            if (UserLogged != null)
                UserLogged(this, new EventArgs());
        }
    }
}
