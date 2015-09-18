using Buget.WebUI.Models.BussinessModels;

namespace Buget.WebUI.Interfaces.UserAccount
{
    public interface IUserAccountService
    {        
        UserModel LogOn(string login, string password);
        UserModel Register(string login, string password);
        UserModel GetUser(string login);
    }
}