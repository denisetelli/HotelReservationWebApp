using AutoMapper;
using Business.Services.Interfaces;
using Commom.DTOs;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class RoomService : IRoomService
    {
        private IRoomRepository _roomRepository;
        private IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public void Add(RoomDTO room)
        {
            _roomRepository.Add(_mapper.Map<Room>(room));
        }

        public void Delete(int roomId)
        {
            _roomRepository.Delete(roomId);
        }

        public void Edit(RoomDTO room)
        {
            _roomRepository.Edit(_mapper.Map<Room>(room));
        }

        public RoomDTO FindById(int roomId)
        {
            var room = _roomRepository.FindById(roomId);
            return _mapper.Map<RoomDTO>(room);
        }

        public IEnumerable<RoomDTO> Get()
        {
            var rooms = _roomRepository.GetAll();
            var roomsDTO = _mapper.Map<List<RoomDTO>>(rooms);
            return roomsDTO;
        }

        public bool IsCodeAvaliable(string code)
        {
            return _roomRepository.IsCodeAvaliable(code);
        }

        public int GetMaxOfGuests(int roomId)
        {
            return _roomRepository.GetMaxOfGuests(roomId);
        }

        public IEnumerable<RoomDTO> GetRoomsByCategory(int roomCategoryId)
        {
            var rooms = _roomRepository.GetRoomsByCategory(roomCategoryId);
            return _mapper.Map<List<RoomDTO>>(rooms);
        }

        public IEnumerable<RoomDTO> GetAvailable(IEnumerable<int> occupiedRoomId, int roomCategoryId)
        {
            var availableRooms = _roomRepository.GetAvailable(occupiedRoomId, roomCategoryId);            
            var availableRoomsDto = _mapper.Map<List<RoomDTO>>(availableRooms);
            return availableRoomsDto;
        }
    }
}

