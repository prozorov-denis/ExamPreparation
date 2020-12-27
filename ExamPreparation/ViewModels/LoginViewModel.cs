using DAL.Entities;
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
        private ExamDbContext db;

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
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            Success = false;
            CurrentUser = null;
        }

        public LoginViewModel(ExamDbContext db)
        {
            this.db = db;
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
                        List<User> users = db.User.ToList();

                        User user = users.Where(u => u.Login == UserLogin).FirstOrDefault();

                        if (user != null)
                        {
                            if (user.Password == UserPassword.ToString())
                                Success = true;
                            if (Success)
                            {
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
