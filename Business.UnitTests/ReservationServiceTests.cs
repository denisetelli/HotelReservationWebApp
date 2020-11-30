using AutoMapper;
using Business.Services;
using Business.Services.Interfaces;
using Commom.DTOs;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;
using Xunit;

namespace Business.UnitTests
{
    public class ReservationServiceTests
    {
        [Fact]
        public void Add_ReservationDtoAsParameter_ShouldCallAddOnce()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();

            Reservation reservation = new Reservation();
            reservationRepositoryMock.Setup(_ => _.Add(It.IsAny<Reservation>()));

            ReservationDTO reservationDto = new ReservationDTO();
            mapperMock.Setup(_ => _.Map<ReservationDTO>(reservation)).Returns(reservationDto);

            ReservationService reservationService = new ReservationService(
                 reservationRepositoryMock.Object,
                 mapperMock.Object,
                 categoryServiceMock.Object,
                 roomServiceMock.Object);

            //Act
            reservationService.Add(reservationDto);

            //Assert
            reservationRepositoryMock.Verify(_ => _.Add(It.IsAny<Reservation>()), Times.Once);
        }

        [Fact]
        public void Edit_ReservationDtoAsParameter_ShouldCallEditOnce()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();

            Reservation reservation = new Reservation();
            reservationRepositoryMock.Setup(_ => _.Edit(It.IsAny<Reservation>()));

            ReservationDTO reservationDto = new ReservationDTO();
            mapperMock.Setup(_ => _.Map<ReservationDTO>(reservation)).Returns(reservationDto);

            ReservationService reservationService = new ReservationService(
                 reservationRepositoryMock.Object,
                 mapperMock.Object,
                 categoryServiceMock.Object,
                 roomServiceMock.Object);

            //Act
            reservationService.Edit(reservationDto);

            //Assert
            reservationRepositoryMock.Verify(_ => _.Edit(It.IsAny<Reservation>()), Times.Once);
        }

        [Fact]
        public void Cancel_IdAsParameter_ReturnTrue()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            int id = 7;

            reservationRepositoryMock.Setup(_ => _.Cancel(It.IsAny<int>())).Returns(true);

            ReservationService reservationService = new ReservationService(
                reservationRepositoryMock.Object,
                mapperMock.Object,
                categoryServiceMock.Object,
                roomServiceMock.Object);

            //Act
            var result = reservationService.Cancel(id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Cancel_IdAsParameter_ReturnFalse()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            int id = 7;

            reservationRepositoryMock.Setup(_ => _.Cancel(It.IsAny<int>())).Returns(false);

            ReservationService reservationService = new ReservationService(
                 reservationRepositoryMock.Object,
                 mapperMock.Object,
                 categoryServiceMock.Object,
                 roomServiceMock.Object);

            //Act
            var result = reservationService.Cancel(id);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAll_ReturnEmptyListReservations()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();

            List<Reservation> reservations = new List<Reservation>();
            reservationRepositoryMock.Setup(_ => _.GetAll()).Returns(reservations);

            List<ReservationDTO> reservationsDto = new List<ReservationDTO>();
            mapperMock.Setup(_ => _.Map<List<ReservationDTO>>(reservations)).Returns(reservationsDto);

            ReservationService reservationService = new ReservationService(
                 reservationRepositoryMock.Object,
                 mapperMock.Object,
                 categoryServiceMock.Object,
                 roomServiceMock.Object);

            //Act
            var result = reservationService.GetAll();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAll_ReturnReservations()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            var id = 7;
            Reservation reservation = new Reservation
            {
                ReservationId = id
            };
            ReservationDTO reservationDto = new ReservationDTO
            {
                ReservationId = id
            };

            List<Reservation> reservations = new List<Reservation>();
            reservations.Add(reservation);
            reservationRepositoryMock.Setup(_ => _.GetAll()).Returns(reservations);

            List<ReservationDTO> reservationsDto = new List<ReservationDTO>();
            reservationsDto.Add(reservationDto);
            mapperMock.Setup(_ => _.Map<List<ReservationDTO>>(reservations)).Returns(reservationsDto);

            ReservationService reservationService = new ReservationService(
               reservationRepositoryMock.Object,
               mapperMock.Object,
               categoryServiceMock.Object,
               roomServiceMock.Object);

            //Act
            var result = reservationService.GetAll();

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public void FindById_IdAsParamater_ReturnReservation()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            int id = 7;

            Reservation reservation = new Reservation();
            reservationRepositoryMock.Setup(_ => _.FindById(It.IsAny<int>())).Returns(reservation);

            ReservationDTO reservationDto = new ReservationDTO();
            mapperMock.Setup(_ => _.Map<ReservationDTO>(reservation)).Returns(reservationDto);

            ReservationService reservationService = new ReservationService(
                reservationRepositoryMock.Object,
                mapperMock.Object,
                categoryServiceMock.Object,
                roomServiceMock.Object);

            //Act
            var result = reservationService.FindById(id);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetRatePerCategory_RoomCategoryIdAsParameter_ReturnDouble()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            double rate = 100.00;
            int roomCategoryId = 7;

            categoryServiceMock.Setup(_ => _.GetRate(It.IsAny<int>())).Returns(rate);
            CategoryService categoryService = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object);

            ReservationService reservationService = new ReservationService(
                reservationRepositoryMock.Object,
                mapperMock.Object,
                categoryServiceMock.Object,
                roomServiceMock.Object);

            //Act
            var result = reservationService.GetRatePerCategory(roomCategoryId);

            //Assert
            Assert.Equal(rate, result);
        }

        [Fact]
        public void TotalNights_ValidReservationDTOAsParameter_ReturnDepartureandArrivalDifference()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();

            ReservationService reservationService = new ReservationService
                (reservationRepositoryMock.Object,
                mapperMock.Object,
                categoryServiceMock.Object,
                roomServiceMock.Object);

            ReservationDTO reservation = new ReservationDTO
            {
                Arrival = new System.DateTime(2019, 12, 15),
                Departure = new System.DateTime(2019, 12, 16)
            };

            //Act
            var result = reservationService.TotalNights(reservation);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetOccupiedRooms_RoomCategoryIdArrivalDepartureAsParameter_ReturnOccupiedRoomsIds()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            int id = 7;
            DateTime arrival = new DateTime(2019, 11, 20);
            DateTime departure = new DateTime(2019, 11, 22);

            reservationRepositoryMock.Setup(_ => _.FindReservations(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()));

            ReservationService reservationService = new ReservationService
            (reservationRepositoryMock.Object,
            mapperMock.Object,
            categoryServiceMock.Object,
            roomServiceMock.Object);

            //Act
            var result = reservationService.GetOccupiedRooms(id, arrival, departure);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAvailableRooms_RoomCategoryIdArrivalDepartureAsParameter_ReturnRooms()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            var reservationServiceMock = new Mock<IReservationService>();
            int id = 7;
            DateTime arrival = new DateTime(2019, 11, 20);
            DateTime departure = new DateTime(2019, 11, 22);

            //RESERVATION SERVICE - GetOccupiedRooms
            List<int> occupiedRooms = new List<int>
            {
                id
            };
            reservationServiceMock.Setup(_ => _.GetOccupiedRooms(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(occupiedRooms);

            //RESERVATION REPOSITORY - FindReservations
            Reservation reservation = new Reservation
            {
                ReservationId = id
            };
            List<Reservation> reservations = new List<Reservation>
            {
                reservation
            };
            reservationRepositoryMock.Setup(_ => _.FindReservations(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(reservations);

            //ROOM SERVICE - GetAvailable
            RoomDTO room = new RoomDTO
            {
                RoomId = id
            };
            List<RoomDTO> rooms = new List<RoomDTO>
            {
                room
            };
            roomServiceMock.Setup(_ => _.GetAvailable(It.IsAny<List<int>>(), It.IsAny<int>())).Returns(rooms);

            ReservationService reservationService = new ReservationService(
                reservationRepositoryMock.Object,
                mapperMock.Object,
                categoryServiceMock.Object,
                roomServiceMock.Object);

            //Act
            var result = reservationService.GetAvailableRooms(id, arrival, departure).ToList();

            //Assert
            Assert.Equal(rooms[0].RoomId, result[0].RoomId);
        }

        [Fact]
        public void GetTodayArrivals_ReturnReservations()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            var id = 7;
            Reservation reservation = new Reservation
            {
                ReservationId = id
            };
            ReservationDTO reservationDto = new ReservationDTO
            {
                ReservationId = id
            };

            List<Reservation> reservations = new List<Reservation>();
            reservations.Add(reservation);
            reservationRepositoryMock.Setup(_ => _.GetTodayArrivals()).Returns(reservations);

            List<ReservationDTO> reservationsDto = new List<ReservationDTO>();
            reservationsDto.Add(reservationDto);
            mapperMock.Setup(_ => _.Map<List<ReservationDTO>>(reservations)).Returns(reservationsDto);

            ReservationService reservationService = new ReservationService(
                  reservationRepositoryMock.Object,
                  mapperMock.Object,
                  categoryServiceMock.Object,
                  roomServiceMock.Object);

            //Act
            var result = reservationService.GetTodayArrivals();

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public void FindReservations_ArrivalAndDepartureAsParameter_ReturnReservations()
        {
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            DateTime arrival = new DateTime(2019, 11, 20);
            DateTime departure = new DateTime(2019, 11, 22);
            var page = 1;
            var size = 5;
            var id = 7;
            Reservation reservation = new Reservation
            {
                ReservationId = id
            };
            ReservationDTO reservationDto = new ReservationDTO
            {
                ReservationId = id
            };

            List<ReservationDTO> reservations = new List<ReservationDTO> { reservationDto };
            reservationRepositoryMock.Setup(_ => _.FindReservations(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>())).Returns(reservations.ToPagedList());

            List<ReservationDTO> reservationsDto = new List<ReservationDTO> { reservationDto };
            mapperMock.Setup(_ => _.Map<List<ReservationDTO>>(reservations)).Returns(reservationsDto);

            ReservationService reservationService = new ReservationService
                 (reservationRepositoryMock.Object,
                 mapperMock.Object,
                 categoryServiceMock.Object,
                 roomServiceMock.Object);

            //Act
            var result = reservationService.FindReservations(arrival, departure, page,size);

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public void GetPaginatedReservations_PageAndSizeAsParameter_ReturnPageOfReservations()
        {
            //Arrange
            var reservationRepositoryMock = new Mock<IReservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var roomServiceMock = new Mock<IRoomService>();
            var pagedListMock = new Mock<IPagedList>();
            int page = 1;
            int size = 10;
            ReservationDTO reservationDto = new ReservationDTO
            {
                ReservationId = 7
            };

            List<ReservationDTO> reservations = new List<ReservationDTO> { reservationDto };
            reservationRepositoryMock.Setup(_ => _.GetPaginatedReservations(It.IsAny<int>(), It.IsAny<int>())).Returns(reservations.ToPagedList());

            ReservationService reservationService = new ReservationService
                (reservationRepositoryMock.Object,
                mapperMock.Object,
                categoryServiceMock.Object,
                roomServiceMock.Object);

            //Act
            var result = reservationService.GetPaginatedReservations(page, size);

            //Assert
            Assert.NotNull(result);
        }
    }
}
