using DataAccess.Models;
using System.Collections.Generic;
using AutoMapper;
using Commom.Security;
using Business.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using Commom.DTOs;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public void Add(UserDTO user)
        {
            string cryptPassword = Cryptography.CryptographPassword(user.Password);
            user.Password = cryptPassword;
            _userRepository.Add(_mapper.Map<User>(user));
        }

        public UserDTO FindById(int? id)
        {
            User user = _userRepository.FindById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public void Delete(int? id)
        {
            _userRepository.Delete(id);
        }

        public void Edit(UserDTO user)
        {
            _userRepository.Edit(_mapper.Map<User>(user));
        }

        public void UpdateProfile(UserDTO user)
        {
            string cryptPassword = Cryptography.CryptographPassword(user.Password);
            user.Password = cryptPassword;
            _userRepository.UpdateProfile(_mapper.Map<User>(user));
        }

        public UserDTO Authenticate(string email, string password)
        {
            string cryptPassword = Cryptography.CryptographPassword(password);
            User user = _userRepository.GetByEmailAndPassword(email, cryptPassword);

            if (user != null)
            {
                bool isValidPassword = user.Password == cryptPassword;

                if (isValidPassword)
                {
                    return _mapper.Map<UserDTO>(user);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<UserDTO> FindUserByName(string name)
        {
            var users = _userRepository.FindUserByName(name);
            var usersDto = _mapper.Map<List<UserDTO>>(users);
            return usersDto;
        }

        public bool IsEmailAvaliable(string email, int id)
        {
            return _userRepository.IsEmailAvaliable(email, id);
        }

        public UserDTO FindByEmail (string email)
        {
            User user = _userRepository.FindByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }
    }
}

