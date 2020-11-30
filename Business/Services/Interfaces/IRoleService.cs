using Commom.DTOs;
using System.Collections.Generic;

namespace Business.Services.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDTO> Get();
    }
}
