using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TurboAz.Commands;
using TurboAz.Models;
using TurboAz.Repositories;

namespace TurboAz.ViewModels
{
    public class LoginView : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private string errorMessage;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand LoginCommand { get; }

        private readonly UserRepository userRepository;

        public LoginView()
        {
            userRepository = new UserRepository("Server= localhost; Database=TurboAz; Integrated Security=True;");

            LoginCommand = new RelayCommand(LoginExecute);
        }

        private void LoginExecute()
        {
            User user = userRepository.GetUserByLogin(Login);

            if (user != null && user.Password == Password)
            {
                // Login successful
                if (user.Login == "Admin")
                {
                    // Open admin window
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();

                }
                else if (user.Login == "Moderator")
                {
                    // Open moderator window
                    ModeratorWindow moderatorWindow = new ModeratorWindow();
                    moderatorWindow.Show();
                }
                else
                {
                    // Open user window
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();

                }
            }
            else
            {
                // Login failed
                ErrorMessage = "Invalid login credentials.";
            }
        }
      

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}