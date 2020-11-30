using AutoMapper;
using Business.Services;
using Commom.DTOs;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace Business.UnitTests
{
    public class RoleServiceTests
    {
        [Fact]
        public void Get_ReturnEmptyListRoles()
        {
            //Arrange
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var mapperMock = new Mock<IMapper>();

            List<Role> roles = new List<Role>();
            roleRepositoryMock.Setup(_ => _.GetAll()).Returns(roles);

            List<RoleDTO> roleDTOs = new List<RoleDTO>();
            mapperMock.Setup(_ => _.Map<List<RoleDTO>>(roles)).Returns(roleDTOs);

            RoleService roleService = new RoleService(roleRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = roleService.Get();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_ReturnRoles()
        {
            //Arrange
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var mapperMock = new Mock<IMapper>();
            var id = 7;
            Role role = new Role
            {
                RoleId = id
            };
            RoleDTO roleDto = new RoleDTO
            {
                RoleId = id
            };

            List<Role> roles = new List<Role>();
            roles.Add(role);
            roleRepositoryMock.Setup(_ => _.GetAll()).Returns(roles);

            List<RoleDTO> roleDTOs = new List<RoleDTO>();
            roleDTOs.Add(roleDto);
            mapperMock.Setup(_ => _.Map<List<RoleDTO>>(roles)).Returns(roleDTOs);

            RoleService roleService = new RoleService(roleRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = roleService.Get();

            //Assert
            Assert.True(result.Any());
        }
    }
}
