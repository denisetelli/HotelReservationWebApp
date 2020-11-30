using AutoMapper;
using Business.Services;
using Commom.DTOs;
using Commom.Security;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Business.UnitTests
{
    public class UserServiceTests
    {
        //EXAMPLE
        //[Theory]
        //[InlineData("Denise", 33)]
        //[InlineData("Matheus", 18)]
        //public void Test2(string name, int age)
        //{
        //    Assert.True(false);
        //}


        [Fact]
        public void GetAll_ReturnEmptyListUsers()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            List<User> list = new List<User>();
            userRepositoryMock.Setup(_ => _.GetAll()).Returns(list);

            List<UserDTO> listDto = new List<UserDTO>();
            mapperMock.Setup(_ => _.Map<List<UserDTO>>(list)).Returns(listDto);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.GetAll();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAll_ReturnUsers()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var name = "Tony";
            User user = new User
            {
                FirstName = name
            };
            UserDTO userDTO = new UserDTO
            {
                FirstName = name
            };

            List<User> list = new List<User>();
            list.Add(user);
            userRepositoryMock.Setup(_ => _.GetAll()).Returns(list);

            List<UserDTO> listDto = new List<UserDTO>();
            listDto.Add(userDTO);
            mapperMock.Setup(_ => _.Map<List<UserDTO>>(list)).Returns(listDto);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.GetAll();

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public void Add_UserDTOAsParameter_ShouldCallAddOnce()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            string password = "caco123";

            User user = new User
            {
                Password = password
            };
            userRepositoryMock.Setup(_ => _.Add(It.IsAny<User>()));

            UserDTO userDTO = new UserDTO
            {
                Password = password
            };
            mapperMock.Setup(_ => _.Map<UserDTO>(user)).Returns(userDTO);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            userService.Add(userDTO);

            //Assert
            userRepositoryMock.Verify(_ => _.Add(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void FindById_IdAsParameter_ReturnUser()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;

            User user = new User
            {
                UserId = id
            };
            userRepositoryMock.Setup(_ => _.FindById(It.IsAny<int>())).Returns(user);

            UserDTO userDTO = new UserDTO
            {
                UserId = id
            };
            mapperMock.Setup(_ => _.Map<UserDTO>(user)).Returns(userDTO);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.FindById(id);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_IdAsParameter_ShouldCallDeleteOnce()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;

            userRepositoryMock.Setup(_ => _.Delete(It.IsAny<int>()));

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            userService.Delete(id);

            //Assert
            userRepositoryMock.Verify(_ => _.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Edit_UserDTOAsParameter_ShouldCallEditOnce()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            User user = new User();
            userRepositoryMock.Setup(_ => _.Edit(It.IsAny<User>()));

            UserDTO userDTO = new UserDTO();
            mapperMock.Setup(_ => _.Map<UserDTO>(user)).Returns(userDTO);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            userService.Edit(userDTO);

            //Assert
            userRepositoryMock.Verify(_ => _.Edit(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void UpdateProfile_UserDTOAsParameter_ShouldCallUpdateProfileOnce()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            string password = "caco123";

            User user = new User
            {
                Password = password
            };
            userRepositoryMock.Setup(_ => _.UpdateProfile(It.IsAny<User>()));

            UserDTO userDTO = new UserDTO
            {
                Password = password
            };
            mapperMock.Setup(_ => _.Map<UserDTO>(user)).Returns(userDTO);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            userService.UpdateProfile(userDTO);

            //Assert
            userRepositoryMock.Verify(_ => _.UpdateProfile(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void Authenticate_EmailAndPasswordAsParameter_ReturnUser()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            string email = "tony@stark.com";
            string password = "anything";
            string cryptPassword = Cryptography.CryptographPassword(password);
            User user = new User
            {
            Password=cryptPassword
            };

            userRepositoryMock.Setup(_ => _.GetByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            UserDTO userDto = new UserDTO
            {
                Password = cryptPassword
            };
            mapperMock.Setup(_ => _.Map<UserDTO>(user)).Returns(userDto);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.Authenticate(email, password);

            //Asseert
            Assert.NotNull(result);
        }

        [Fact]
        public void Authenticate_EmailAndPasswordAsParameter_ReturnNull()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            string email = "tony@stark.com";
            string password = "anything";
            User user = new User
            {
                Password = password
            };

            userRepositoryMock.Setup(_ => _.GetByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.Authenticate(email, password);

            //Asseert
            Assert.Null(result);
        }

        [Fact]
        public void FindUserByName_NameAsParameter_ReturnEmptyListUsers()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            string name = "Tony";

            List<User> users = new List<User>();
            userRepositoryMock.Setup(_ => _.FindUserByName(It.IsAny<string>())).Returns(users);

            List<UserDTO> usersDto = new List<UserDTO>();
            mapperMock.Setup(_ => _.Map<List<UserDTO>>(users)).Returns(usersDto);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.FindUserByName(name);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void FindUserByName_NameAsParameter_ReturnUsers()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            string name = "Tony";
            User user = new User
            {
                FirstName =name
            };
            UserDTO userDTO = new UserDTO
            {
                FirstName =name
            };

            List<User> users = new List<User>();
            users.Add(user);
            userRepositoryMock.Setup(_ => _.FindUserByName(It.IsAny<string>())).Returns(users);

            List<UserDTO> usersDto = new List<UserDTO>();
            usersDto.Add(userDTO);
            mapperMock.Setup(_ => _.Map<List<UserDTO>>(users)).Returns(usersDto);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.FindUserByName(name);

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public void IsEmailAvaliable_EmailAndIdAsParameter_ReturnTrue()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            string email = "tony@stark.com";
            int id = 7;

            userRepositoryMock.Setup(_ => _.IsEmailAvaliable(It.IsAny<string>(), It.IsAny<int>())).Returns(true);
            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.IsEmailAvaliable(email, id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmailAvaliable_EmailAndIdAsParameter_ReturnFalse()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            string email = "tony@stark.com";
            int id = 7;

            userRepositoryMock.Setup(_ => _.IsEmailAvaliable(It.IsAny<string>(), It.IsAny<int>())).Returns(false);
            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.IsEmailAvaliable(email, id);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void FindByEmail_ValidEmailAsParameter_ReturnUsers()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            string email = "tony@stark.com";
            User user = new User
            {
                Email = email
            };
            userRepositoryMock.Setup(_ => _.FindByEmail(It.IsAny<string>())).Returns(user);
            //OR userRepositoryMock.Setup(_ => _.FindByEmail(It.Is<string>(x=>x==email))).Returns(user);

            UserDTO userDto = new UserDTO
            {
                Email = email
            };
            mapperMock.Setup(_ => _.Map<UserDTO>(user)).Returns(userDto);

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.FindByEmail(email);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void FindByEmail_InvalidEmailAsParameter_ReturnNull()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            string email = "tony@stark.com";

            UserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = userService.FindByEmail(email);

            //Assert
            Assert.Null(result);
        }
    }
}
