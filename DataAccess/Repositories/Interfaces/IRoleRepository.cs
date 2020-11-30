using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
    }
}
