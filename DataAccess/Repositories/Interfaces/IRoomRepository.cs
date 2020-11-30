using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();

        void Add(Room room);

        void Delete(int roomId);

        void Edit(Room room);

        Room FindById(int roomId);

        bool IsCodeAvaliable(string code);

        int GetMaxOfGuests(int roomId);

        List<Room> GetRoomsByCategory(int roomCategoryId);

        IEnumerable<Room> GetAvailable(IEnumerable<int> occupiedRoomId, int roomCategoryId);
    }
}
