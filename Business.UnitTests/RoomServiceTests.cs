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
    public class RoomServiceTests
    {
        [Fact]
        public void Add_RoomDTOAsParameter_ShouldCallAddOnce()
        {
            //Arrange
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var mapperMock = new Mock<IMapper>();

            Room room = new Room();
            roomRepositoryMock.Setup(_ => _.Add(It.IsAny<Room>()));

            RoomDTO roomDTO = new RoomDTO();
            mapperMock.Setup(_ => _.Map<RoomDTO>(room)).Returns(roomDTO);

            RoomService roomService = new RoomService(roomRepositoryMock.Object, mapperMock.Object);

            //Act
            roomService.Add(roomDTO);

            //Assert
            roomRepositoryMock.Verify(_ => _.Add(It.IsAny<Room>()), Times.Once());         
        }

        [Fact]
        public void Delete_RoomIdAsParameter_ShouldCallDeleteOnce()
        {
            //Arrange
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7; 
         
            roomRepositoryMock.Setup(_ => _.Delete(It.IsAny<int>()));

            RoomService roomService = new RoomService(roomRepositoryMock.Object, mapperMock.Object);

            //Act
            roomService.Delete(id);

            //Assert
            roomRepositoryMock.Verify(_ => _.Delete(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void Edit_RoomIdAsParameter_ShouldCallEditOnce()
        {
            //Arrange
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;
            Room room = new Room
            {
                RoomId = id
            };
            RoomDTO roomDTO = new RoomDTO
            {
                RoomId = id
            };

            roomRepositoryMock.Setup(_ => _.Edit(It.IsAny<Room>()));
            mapperMock.Setup(_ => _.Map<RoomDTO>(room)).Returns(roomDTO);

            RoomService roomService = new RoomService(roomRepositoryMock.Object, mapperMock.Object);

            //Act
            roomService.Edit(roomDTO);

            //Assert
            roomRepositoryMock.Verify(_ => _.Edit(It.IsAny<Room>()), Times.Once());  
        }

        [Fact]
        public void Get_ReturnEmptyListRooms()
        {
            //Arrange
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var mapperMock = new Mock<IMapper>();

            List<Room> rooms = new List<Room>();
            roomRepositoryMock.Setup(_ => _.GetAll()).Returns(rooms);

            List<RoomDTO> roomDTOs = new List<RoomDTO>();
            mapperMock.Setup(_ => _.Map<List<RoomDTO>>(rooms)).Returns(roomDTOs);

            RoomService roomService = new RoomService(roomRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = roomService.Get();

            //Assert
            Assert.NotNull(result);
        }


        [Fact]
        public void Get_ReturnRooms()
        {
            //Arrange
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;
            Room room = new Room
            {
                RoomId = id
            };
            RoomDTO roomDTO = new RoomDTO
            {
                RoomId = id
            };

            List<Room> rooms = new List<Room>();
            rooms.Add(room);
            roomRepositoryMock.Setup(_ => _.GetAll()).Returns(rooms);

            List<RoomDTO> roomDTOs = new List<RoomDTO>();
            roomDTOs.Add(roomDTO);
            mapperMock.Setup(_ => _.Map<List<RoomDTO>>(rooms)).Returns(roomDTOs);

            RoomService roomService = new RoomService(roomRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = roomService.Get();

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public void IsCodeAvaliable_RoomCodeAsParameter_ReturnTrue()
        {
            //Arrange
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var mapperMock = new Mock<IMapper>();
            string code = "X405";

            roomRepositoryMock.Setup(_ => _.IsCodeAvaliable(It.IsAny<string>())).Returns(true);

            RoomService roomService = new RoomService(roomRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = roomService.IsCodeAvaliable(code);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsCodeAvaliable_RoomCodeAsParameter_ReturnFalse()
        {
            //Arrange
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var mapperMock = new Mock<IMapper>();
            string code = "X405";

            roomRepositoryMock.Setup(_ => _.IsCodeAvaliable(It.IsAny<string>())).Returns(false);

            RoomService roomService = new RoomService(roomRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = roomService.IsCodeAvaliable(code);

            //Assert
            Assert.False(result);
        }
    }
}
