using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private readonly HotelContext _appDbContext;

        public RoleRepository(HotelContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Role> GetAll()
        {
            return _appDbContext.Roles;
        }
    }
}

