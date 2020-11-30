
using Commom.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTransilvania.ViewModels
{
    public class CreateUserViewModel
    {
        UserDTO User { get; set; }

        IEnumerable<RoleDTO> Roles { get; set; }

        RoleDTO SelectedRole { get; set; }
    }
}
