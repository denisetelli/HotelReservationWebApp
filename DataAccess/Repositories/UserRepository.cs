using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelContext _appDbContext;
        private IQueryable<User> _userQueryAsNoTracking => _appDbContext?.Users.AsNoTracking();

        public UserRepository(HotelContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _userQueryAsNoTracking.Where(_ => !_.IsDeleted).Include(_ => _.Role).ToList();
        }

        public void Add(User user)
        {
            _appDbContext.Add(user);
            _appDbContext.SaveChanges();
        }

        public User FindById(int? id)
        {
            return _appDbContext.Users.Where(_ => !_.IsDeleted).Include(x => x.Role).FirstOrDefault(_ => _.UserId == id);
        }

        public void Delete(int? userId)
        {
            User persistedUser = FindById(userId);

            if (persistedUser != null)
            {
                persistedUser.IsDeleted = true;
                _appDbContext.SaveChanges();
            }
        }

        public bool Edit(User user)
        {
            User userFromDb = FindById(user.UserId);

            if (userFromDb != null)
            {                
                userFromDb.FirstName = user.FirstName;
                userFromDb.LastName = user.LastName;
                userFromDb.Email = user.Email;
                userFromDb.ChangeDate = DateTime.Now;
                userFromDb.RoleId = user.RoleId;

                return _appDbContext.SaveChanges() == 1;
            }
            return false;
        }

        public void UpdateProfile(User user)
        {
            User userFromDb = FindById(user.UserId);

            if (userFromDb != null)
            {
                userFromDb.FirstName = user.FirstName;
                userFromDb.LastName = user.LastName;
                userFromDb.Password = user.Password;
                userFromDb.ChangeDate = DateTime.Now;

                _appDbContext.SaveChanges();
            }
        }

        public User GetByEmailAndPassword(string email, string cryptPassword)
        {
            User user = GetAll().FirstOrDefault
                        (_ => _.Email == email && _.Password == cryptPassword);
            return user;
        }

        public IEnumerable<User> FindUserByName(string name)
        {
            var users = GetAll();
            List<User> listOfUsers = new List<User>();

            if (!String.IsNullOrEmpty(name))
            {
                listOfUsers = users.Where(s => s.FirstName.Contains(name, StringComparison.InvariantCultureIgnoreCase)
                                  || s.LastName.Contains(name, StringComparison.InvariantCultureIgnoreCase))
                                  .ToList();
            }
            return listOfUsers;
        }

        public bool IsEmailAvaliable(string email, int id = -1)
        {
            var isEmailAlreadyBeingUsed = _appDbContext.Users.Any(_ => !_.IsDeleted && _.UserId != id && _.Email == email);
            return !isEmailAlreadyBeingUsed;
        }

        public User FindByEmail(string email)
        {
            return _appDbContext.Users.Where(_ => !_.IsDeleted).Include(x => x.Role).FirstOrDefault(_ => _.Email == email);
        }
    }
}

