using Practice.Models;

namespace Practice.DI
{
    public interface IUserService
    {
        bool validateLogin(string username, string password);

        bool RegisterUser(UserModel model);
    }
}
