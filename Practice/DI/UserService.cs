using Practice.Data;
using Practice.Models;

namespace Practice.DI
{
    public class UserService : IUserService
    {
        ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public bool RegisterUser(UserModel model)
        {
            bool alreadyExist = _context.UserModel.Count(x=> x.UserName == model.UserName)>0;

            if (!alreadyExist) // alreadyExist == 0
            {
                _context.UserModel.Add(model);
                _context.SaveChanges();
                return true;
            }
            return false;
            
        }
        public bool validateLogin(string username, string password)
        {
            bool validUser = _context.UserModel.Any(x=>x.UserName == username && x.Password == password);
            return validUser;
        }
    }
}
