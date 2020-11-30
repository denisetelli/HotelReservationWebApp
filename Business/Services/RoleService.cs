using AutoMapper;
using Business.Services.Interfaces;
using Commom.DTOs;
using DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace Business.Services
{
    public class RoleService: IRoleService
    {
        private IRoleRepository _roleRepository;
        private IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public IEnumerable<RoleDTO> Get()
        {
            var roles = _roleRepository.GetAll();
            var rolesDTO = _mapper.Map<List<RoleDTO>>(roles);
            return rolesDTO;
        }
    }
}

