using System.Collections.Generic;

namespace DataLayer
{
    public interface IUserModelRepositories
    {
        IEnumerable<UsersModel> GetAllUsers();
        UsersModel GetUserById(int id);
        bool InsertUser(UsersModel usersModel);
        bool UpdateUser(UsersModel usersModel);
        bool DeleteUser(UsersModel usersModel);
        bool DeleteUser(int userId);
        bool Save();
    }
}