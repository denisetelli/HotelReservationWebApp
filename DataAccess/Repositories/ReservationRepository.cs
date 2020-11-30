using Commom.DTOs;
using Commom.Enums;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelContext _appDbContext;
        private IQueryable<Reservation> _reservationQueryAsNoTracking => _appDbContext?.Reservations.AsNoTracking();

        public ReservationRepository(HotelContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Reservation reservation)
        {
            reservation.Status = ReservationStatusEnum.Reserved;
            reservation.CreationDate = DateTime.Now;

            foreach (var item in reservation.ReservationClients)
            {
                item.Reservation = reservation;
                _appDbContext.Add(item);
            }

            _appDbContext.Add(reservation);
            _appDbContext.SaveChanges();
        }

        public bool Edit(Reservation reservation)
        {
            Reservation persistedReservation = FindById(reservation.ReservationId);

            if (persistedReservation != null)
            {
                persistedReservation.Arrival = reservation.Arrival;
                persistedReservation.ContactPersonId = reservation.ContactPersonId;
                persistedReservation.Departure = reservation.Departure;
                persistedReservation.MainGuestId = reservation.MainGuestId;
                persistedReservation.ReservationClients = reservation.ReservationClients;
                persistedReservation.RoomCategoryId = reservation.RoomCategoryId;
                persistedReservation.RoomId = reservation.RoomId;

                _appDbContext.Update(reservation);
                return _appDbContext.SaveChanges() == 1;
            }
            return false;
        }

        public bool Cancel(int reservationId)
        {
            Reservation persistedReservation = FindById(reservationId);
            if (persistedReservation != null)
            {
                persistedReservation.Status = ReservationStatusEnum.Cancelled;
                _appDbContext.Update(persistedReservation);
                return _appDbContext.SaveChanges() == 1;
            }
            return false;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _reservationQueryAsNoTracking
                .Include(_ => _.MainGuest)
                .Include(_ => _.ContactPerson)
                .Include(_ => _.RoomCategory)
                .Include(_ => _.Room)
                .Include(_ => _.ReservationClients)
                .ToList();
        }

        public Reservation FindById(int reservationId)
        {
            return _reservationQueryAsNoTracking
                .Include(_ => _.MainGuest)
                .Include(_ => _.ReservationClients).ThenInclude(x => x.Client)
                .Include(_ => _.ContactPerson)
                .Include(_ => _.RoomCategory)
                .Include(_ => _.Room)
                .FirstOrDefault(_ => _.ReservationId == reservationId);
        }

        public IEnumerable<Reservation> FindReservations(int roomCategoryId, DateTime arrival, DateTime departure)
        {
            return _reservationQueryAsNoTracking
                .Where(_ => _.Status == ReservationStatusEnum.Reserved)
                .Where(_ => arrival >= _.Arrival && arrival < _.Departure && departure > _.Arrival)
                .Where(_ => _.RoomCategoryId == roomCategoryId)
                .ToList();
        }

        public IPagedList<ReservationDTO> FindReservations(DateTime arrival, DateTime departure, int page, int size)
        {
            var resultList = _reservationQueryAsNoTracking
              .Where(_ => _.Arrival >= arrival && _.Arrival < departure && _.Departure <= departure)
              .Include(_ => _.MainGuest)
              .Include(_ => _.ContactPerson)
              .Include(_ => _.RoomCategory)
              .Include(_ => _.Room)
              .OrderByDescending(_ => _.Arrival)
              .ThenBy(_ => _.MainGuest.FirstName)
              .ThenBy(_ => _.MainGuest.LastName)
              .Select(_ => new ReservationDTO
              {
                  Arrival = _.Arrival,
                  ContactPersonFullName = $"{_.ContactPerson.TradeName}{_.ContactPerson.FirstName}{string.Empty}{_.ContactPerson.LastName}",
                  ContactPersonId = _.ContactPersonId,
                  CreationDate = _.CreationDate,
                  Departure = _.Departure,
                  MainGuestFullName = $"{_.MainGuest.FirstName}{string.Empty}{_.MainGuest.LastName}",
                  MainGuestId = _.MainGuestId,
                  ReservationId = _.ReservationId,
                  RoomCategory = _.RoomCategory.Name,
                  RoomCategoryId = _.RoomCategoryId,
                  RoomCode = _.Room.Code,
                  RoomId = _.RoomId,
                  Status = _.Status,
              });

            return resultList.ToPagedList(page, size);
        }

        public IEnumerable<Reservation> GetTodayArrivals()
        {
            return _reservationQueryAsNoTracking
                .Where(_ => _.Arrival == DateTime.Today)
                .Where(_ => _.Status == ReservationStatusEnum.Reserved)
                .Include(_ => _.MainGuest)
                .Include(_ => _.ContactPerson)
                .Include(_ => _.RoomCategory)
                .Include(_ => _.Room)
                .ToList();
        }

        public IPagedList<ReservationDTO> GetPaginatedReservations(int pageNumber, int pageSize)
        {
            var resultList = _reservationQueryAsNoTracking
                .Include(_ => _.MainGuest)
                .Include(_ => _.ContactPerson)
                .Include(_ => _.RoomCategory)
                .Include(_ => _.Room)
                .OrderByDescending(_ => _.Arrival)
                .ThenBy(_ => _.MainGuest.FirstName)
                .ThenBy(_ => _.MainGuest.LastName)
                .Select(_ => new ReservationDTO
                {
                    Arrival = _.Arrival,
                    ContactPersonFullName = $"{_.ContactPerson.TradeName}{_.ContactPerson.FirstName}{string.Empty}{_.ContactPerson.LastName}",
                    ContactPersonId = _.ContactPersonId,
                    CreationDate = _.CreationDate,
                    Departure = _.Departure,
                    MainGuestFullName = $"{_.MainGuest.FirstName}{string.Empty}{_.MainGuest.LastName}",
                    MainGuestId = _.MainGuestId,
                    ReservationId = _.ReservationId,
                    RoomCategory = _.RoomCategory.Name,
                    RoomCategoryId = _.RoomCategoryId,
                    RoomCode = _.Room.Code,
                    RoomId = _.RoomId,
                    Status = _.Status,
                });

            return resultList.ToPagedList(pageNumber, pageSize);
        }
    }
}
