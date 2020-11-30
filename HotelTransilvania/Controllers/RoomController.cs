using Business.Services.Interfaces;
using Commom.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTransilvania.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        private IRoomService _roomService;
        private ICategoryService _categoryService;

        public RoomController(IRoomService roomService, ICategoryService categoryService)
        {
            _roomService = roomService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var rooms = _roomService.Get().OrderBy(_ => _.Code);
            return View(rooms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetViewBagDataRoomCategory();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomDTO room)
        {
            if (IsCodeAvaliable(room.Code))
            {
                room.CreationDate = DateTime.Now;
                room.ChangeDate = DateTime.Now;

                _roomService.Add(room);
                return RedirectToAction("Index");
            }
            else
            {
                SetViewBagDataRoomCategory();
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int roomId)
        {
            _roomService.Delete(roomId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int roomId)
        {
            SetViewBagDataRoomCategory();
            RoomDTO room = _roomService.FindById(roomId);
            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoomDTO room)
        {
            SetViewBagDataRoomCategory();
            _roomService.Edit(room);
            return RedirectToAction("Index");
        }

        private void SetViewBagDataRoomCategory()
        {
            ViewBag.RoomCategoryList = _categoryService.Get();
        }

        private bool IsCodeAvaliable(string code)
        {
            if (!_roomService.IsCodeAvaliable(code))
            {
                ViewData["ErrorMessage"] = "Código já existente.";
                return false;
            }

            return true;
        }
    }
}
