using Commom.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using X.PagedList;

namespace DataAccess.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        void Add(Reservation reservation);

        bool Edit(Reservation reservation);

        bool Cancel(int reservationId);
        
        IEnumerable<Reservation> GetAll();

        Reservation FindById(int reservationId);

        IEnumerable<Reservation> FindReservations(int roomCategoryId, DateTime arrival, DateTime departure);

        //IEnumerable<Reservation> FindReservations(DateTime arrival, DateTime departure);
        IPagedList<ReservationDTO> FindReservations(DateTime arrival, DateTime departure, int page, int size);

        IEnumerable<Reservation> GetTodayArrivals();

        IPagedList<ReservationDTO> GetPaginatedReservations(int page, int size);
    }
}
