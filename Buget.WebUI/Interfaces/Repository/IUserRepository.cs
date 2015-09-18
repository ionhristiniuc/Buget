using Buget.WebUI.Models.BussinessModels;

namespace Buget.WebUI.Interfaces.Repository
{
    public interface IUserRepository
    {
        UserModel GetUser(string login);
        int? AddUser(UserModel userModel);
    }
}
