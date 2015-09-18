using System;
using Buget.WebUI.Interfaces;
using Buget.WebUI.Interfaces.Repository;
using Buget.WebUI.Interfaces.UserAccount;
using Buget.WebUI.Models.BussinessModels;

namespace Buget.WebUI.Services.UserAccountServices
{
    public class UserAccountService : IUserAccountService
    {
        private IUserRepository _userRepository;

        public UserAccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel LogOn(string login, string password)
        {
            var user = _userRepository.GetUser(login);

            if (user != null && user.Password == password)
                return user;
            else
                return null;
        }

        public UserModel Register(string login, string password)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(string login)
        {
            return _userRepository.GetUser(login);
        }
    }
}