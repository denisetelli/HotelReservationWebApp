using Commom.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using X.PagedList;

namespace Business.Services.Interfaces
{
    public interface IReservationService
    {
        void Add(ReservationDTO reservation);

        void Edit(ReservationDTO reservation);

        bool Cancel(int reservationId);

        IEnumerable<ReservationDTO> GetAll();

        ReservationDTO FindById(int reservationId);

        double GetRatePerCategory(int roomCategoryId);

        int TotalNights(ReservationDTO reservation);

        IEnumerable<int> GetOccupiedRooms(int roomCategoryId, DateTime arrival, DateTime departure);

        IEnumerable<RoomDTO> GetAvailableRooms(int roomCategoryId, DateTime arrival, DateTime departure);

        IEnumerable<ReservationDTO> GetTodayArrivals();

        //IEnumerable<ReservationDTO> FindReservations(DateTime arrival, DateTime departure);
        IPagedList<ReservationDTO> FindReservations(DateTime arrival, DateTime departure, int page, int size);

        IPagedList<ReservationDTO> GetPaginatedReservations(int page, int size);
    }
}
