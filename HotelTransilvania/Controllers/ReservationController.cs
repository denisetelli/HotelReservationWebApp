using Microsoft.AspNetCore.Mvc;
using Business.Services.Interfaces;
using Commom.DTOs;
using System.Linq;
using System.Collections.Generic;
using System;
using NToastNotify;
using X.PagedList;
using System.Security.Claims;

namespace HotelTransilvania.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ICategoryService _categoryService;
        private readonly IClientService _clientService;
        private readonly IRoomService _roomService;
        private readonly IToastNotification _toastNotification;
        private readonly IUserService _userService;

        public ReservationController(IReservationService reservationService,
            ICategoryService categoryService, IClientService clientService,
            IRoomService roomService, IToastNotification toastNotification,
            IUserService userService)
        {
            _reservationService = reservationService;
            _categoryService = categoryService;
            _clientService = clientService;
            _roomService = roomService;
            _toastNotification = toastNotification;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(DateTime? arrivalSearch, DateTime? departureSearch, int pageSize, int? page)
        {
            if (ModelState.IsValid)
            {
                int? pageNumber = (page ?? 1);
                SetViewBagDataRecordNumber();

                if (pageSize == 0)
                {
                    pageSize = 10;
                    ViewBag.PageSize = pageSize;

                    if (arrivalSearch != null && departureSearch != null)
                    {
                        var reservations = _reservationService.FindReservations(arrivalSearch.Value, departureSearch.Value, pageNumber.Value, pageSize);
                        return View(reservations);
                    }
                    else
                    {
                        var reservations = _reservationService.GetPaginatedReservations(pageNumber.Value, pageSize);
                        return View(reservations);
                    }
                }
                else
                {
                    ViewBag.PageSize = pageSize;                
                    if (arrivalSearch != null && departureSearch != null)
                    {
                        var reservations = _reservationService.FindReservations(arrivalSearch.Value, departureSearch.Value, pageNumber.Value, pageSize);
                        return View(reservations);
                    }
                    else
                    {
                        var reservations = _reservationService.GetPaginatedReservations(pageNumber.Value, pageSize);
                        return View(reservations);
                    }
                }
                

            }
            return RedirectToAction("Index");
        }
        
        private void SetViewBagDataRecordNumber()
        {
            List<int> number = new List<int>
            {
                5, 
                10,
                15
            };
            ViewBag.RecordNumber = number;
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetViewBagData();
            var reservation = new ReservationDTO
            {
                Arrival = DateTime.Today,
                Departure = DateTime.Today.AddDays(1),
                ReservationClients = new List<ReservationClientDTO>()
            };
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationDTO reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationService.Add(reservation);
                _toastNotification.AddSuccessToastMessage("Reserva criada com sucesso.", new ToastrOptions() { Title = "Show!" });
                return RedirectToAction("Index");
            }

            SetViewBagData();
            return View(reservation);
        }

        [HttpGet]
        public ActionResult Edit(int reservationId)
        {
            SetViewBagData();
            var reservation = _reservationService.FindById(reservationId);
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReservationDTO reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationService.Edit(reservation);
                _toastNotification.AddSuccessToastMessage("Reserva alterada com sucesso.", new ToastrOptions() { Title = "Show!" });
                return RedirectToAction("Index");
            }

            SetViewBagData();
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(int id)
        {
            _reservationService.Cancel(id);
            return RedirectToAction("Index");
        }

        private void SetViewBagData()
        {
            ViewBag.RoomCategoryList = _categoryService.Get();
            ViewBag.RoomAvailabilityList = _roomService.Get();
            ViewBag.OnlyPersonClientList = _clientService.GetOnlyPerson();
            ViewBag.ClientList = _clientService.GetAll();
        }

        [HttpPost]
        public IActionResult AccompanyingListPost(ReservationDTO reservation, [FromForm]int clientId)
        {
            var client = _clientService.FindById(clientId);
            var clientList = reservation.ReservationClients;

            var reservationClient = new ReservationClientDTO()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                ClientId = client.ClientId
            };

            clientList.Add(reservationClient);
            _toastNotification.AddSuccessToastMessage(client.FirstName + " foi adicionado(a) como acompanhante.", new ToastrOptions() { Title = "Feito!" });
            return PartialView("_AccompanyingPartial", reservation);
        }

        [HttpGet]
        public IActionResult GetAvailableRooms(int roomCategoryId, DateTime arrival, DateTime departure)
        {
            var rooms = _reservationService
                .GetAvailableRooms(roomCategoryId, arrival, departure)
                .Select(room => new
                {
                    value = room.RoomId,
                    label = room.Code
                })
                .ToList();

            if (rooms.Count() == 0)
            {
                return new JsonResult(new
                {
                    Rooms = new List<RoomDTO>(),
                    Error = "Não há apartamentos disponíveis nesta data."
                });
            }

            return new JsonResult(new
            {
                Rooms = rooms,
                Error = ""
            });
        }

        [HttpGet]
        public IActionResult GetRate(int roomCategoryId)
        {
            double rate = _categoryService.GetRate(roomCategoryId);
            return new JsonResult(rate);
        }

        [HttpGet]
        public IActionResult SearchClientOnlyPerson(string searchLetters)
        {
            var clientList = _clientService
                 .SearchClientOnlyPerson(searchLetters)
                 .Select(client => new
                 {
                     value = client.FullNamePersonOnly,
                     label = client.FullNamePersonOnly,
                     id = client.ClientId
                 });

            return new JsonResult(clientList);
        }

        [HttpGet]
        public IActionResult SearchClient(string searchLetters)
        {
            var clientList = _clientService
                .SearchClient(searchLetters)
                .Select(client => new
                {
                    value = client.FullName,
                    label = client.FullName,
                    id = client.ClientId
                });

            return new JsonResult(clientList);
        }

        [HttpGet]
        public IActionResult GetMaxOfGuests(int roomId)
        {
            int maxOfGuests = _roomService.GetMaxOfGuests(roomId);
            return new JsonResult(maxOfGuests);
        }
    }
}
