using Commom.DTOs;
using System.Collections.Generic;

namespace Business.Services.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> Get();

        void Add(RoomDTO room);

        void Delete(int roomId);

        void Edit(RoomDTO room);

        RoomDTO FindById(int roomId);

        bool IsCodeAvaliable(string code);

        int GetMaxOfGuests(int roomId);

        IEnumerable<RoomDTO> GetRoomsByCategory(int roomCategoryId);

        IEnumerable<RoomDTO> GetAvailable(IEnumerable<int> occupiedRoomId, int roomCategoryId);
    }
}
