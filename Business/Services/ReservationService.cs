using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Services.Interfaces;
using Commom.DTOs;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using X.PagedList;

namespace Business.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IRoomService _roomService;

        public ReservationService(IReservationRepository reservationRepository,
            IMapper mapper, ICategoryService categoryService, IRoomService roomService)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _categoryService = categoryService;
            _roomService = roomService;
        }

        public void Add(ReservationDTO reservation)
        {
            _reservationRepository.Add(_mapper.Map<Reservation>(reservation));
        }

        public void Edit(ReservationDTO reservation)
        {
            var persistedReservation = _mapper.Map<Reservation>(reservation);
            _reservationRepository.Edit(persistedReservation);
        }

        public bool Cancel(int reservationId)
        {
            return _reservationRepository.Cancel(reservationId);
        }

        public IEnumerable<ReservationDTO> GetAll()
        {
            var reservations = _reservationRepository.GetAll();
            return _mapper.Map<List<ReservationDTO>>(reservations);
        }

        public ReservationDTO FindById(int reservationId)
        {
            Reservation reservation = _reservationRepository.FindById(reservationId);
            return _mapper.Map<ReservationDTO>(reservation);
        }

        public double GetRatePerCategory(int roomCategoryId)
        {
            return _categoryService.GetRate(roomCategoryId);
        }

        public int TotalNights(ReservationDTO reservation)
        {
            DateTime arrival = reservation.Arrival;
            DateTime departure = reservation.Departure;
            return (departure - arrival).Days;
        }

        public IEnumerable<int> GetOccupiedRooms(int roomCategoryId, DateTime arrival, DateTime departure)
        {
            var reservations = _reservationRepository.FindReservations(roomCategoryId, arrival, departure);
            var occupiedRooms = reservations
                .Select(room => room.RoomId)
                .Distinct()
                .ToList();
            return occupiedRooms;
        }

        public IEnumerable<RoomDTO> GetAvailableRooms(int roomCategoryId, DateTime arrival, DateTime departure)
        {
            var occupiedRoomIdList = GetOccupiedRooms(roomCategoryId, arrival, departure);
            var availableRooms = _roomService.GetAvailable(occupiedRoomIdList, roomCategoryId);
            return availableRooms;
        }

        public IEnumerable<ReservationDTO> GetTodayArrivals()
        {
            var reservations = _reservationRepository.GetTodayArrivals();
            return _mapper.Map<List<ReservationDTO>>(reservations);
        }

        public IPagedList<ReservationDTO> FindReservations(DateTime arrival, DateTime departure, int pageNumber, int pageSize)
        {
            return _reservationRepository.FindReservations(arrival, departure, pageNumber, pageSize);
            //return _mapper.Map<List<ReservationDTO>>(reservations);
        }

       public IPagedList<ReservationDTO> GetPaginatedReservations(int pageNumber, int pageSize)
        {
           return _reservationRepository.GetPaginatedReservations(pageNumber, pageSize);
        }                
    }
}
