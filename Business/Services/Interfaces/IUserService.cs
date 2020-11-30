using Commom.DTOs;
using System.Collections.Generic;

namespace Business.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();

        void Add(UserDTO user);

        UserDTO FindById(int? id);

        void Delete(int? userId);

        void Edit(UserDTO user);

        void UpdateProfile(UserDTO user);

        UserDTO Authenticate(string email, string password);

        IEnumerable<UserDTO> FindUserByName(string name);

        bool IsEmailAvaliable(string email, int id);

        UserDTO FindByEmail(string email);      
    }
}
