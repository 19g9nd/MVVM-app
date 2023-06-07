using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboAz.Models;
using TurboAz.Repositories;

namespace TurboAz.ViewModels.Base
{
    public class RegistrationViewModel
    {
        private readonly UserRepository userRepository;

        public RegistrationViewModel(string connectionString)
        {
            userRepository = new UserRepository(connectionString);
        }

        public void RegisterUser(string login, string password)
        {
            User user = new User { Login = login, Password = password };
            userRepository.InsertUser(user);
        }
    }
}
