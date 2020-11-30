using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
     
        void Add(User user);

        User FindById(int? id);

        void Delete(int? userId);

        bool Edit(User user);

        void UpdateProfile(User user);

        User GetByEmailAndPassword(string email, string cryptPassword);

        IEnumerable<User> FindUserByName(string name);

        bool IsEmailAvaliable(string email, int id);

        User FindByEmail(string email);      
    }
}
