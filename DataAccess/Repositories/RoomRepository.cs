using Commom;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _appDbContext;
        private IQueryable<Room> _roomQueryAsNoTracking => _appDbContext?.Rooms.AsNoTracking();

        public RoomRepository(HotelContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Room room)
        {
            _appDbContext.Add(room);
            _appDbContext.SaveChanges();
        }

        public void Delete(int roomId)
        {
            Room roomToBeDeleted = FindById(roomId);

            if (roomToBeDeleted != null)
            {
                roomToBeDeleted.IsDeleted = true;
                _appDbContext.SaveChanges();
            }
        }

        public void Edit(Room room)
        {
            Room roomFromDb = FindById(room.RoomId);

            if (roomFromDb != null)
            {
                roomFromDb.RoomId = room.RoomId;
                roomFromDb.Code = room.Code;
                roomFromDb.MaxOfGuests = room.MaxOfGuests;
                roomFromDb.ChangeDate = DateTime.Now;
                roomFromDb.CategoryId = room.CategoryId;

                _appDbContext.SaveChanges();
            }
        }

        public Room FindById(int roomId)
        {
            return _appDbContext.Rooms
                .Where(_ => !_.IsDeleted)
                .Include(_ => _.Category)
                .FirstOrDefault(_ => _.RoomId == roomId);
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomQueryAsNoTracking
                .Where(_ => !_.IsDeleted)
                .Include(_ => _.Category)
                .ToList();
        }

        public bool IsCodeAvaliable(string code)
        {
            var isNotAvailable = _appDbContext.Rooms.Any(_ => _.Code == code);
            return !isNotAvailable;
        }

        public int GetMaxOfGuests(int roomId)
        {
            var room = FindById(roomId);
            return room?.MaxOfGuests ?? Constants.Default_Room_Max_Guests;
        }

        public List<Room> GetRoomsByCategory(int roomCategoryId)
        {
            return _roomQueryAsNoTracking
                .Where(_ => !_.IsDeleted)
                .Where(room => room.CategoryId == roomCategoryId)
                .ToList();
        }

        public IEnumerable<Room> GetAvailable(IEnumerable<int> occupiedRoomId, int roomCategoryId)
        {
            var availableRooms = _roomQueryAsNoTracking
                .Where(_ => _.CategoryId == roomCategoryId
                && !occupiedRoomId.Contains(_.RoomId))
                .ToList();

            return availableRooms;           
        }
    }
}
