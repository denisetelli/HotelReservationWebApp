using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Interfaces;
using Commom.DTOs;
using HotelTransilvania.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelTransilvania.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class HomeController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public HomeController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public IActionResult Index(UserDTO user)
        {
            ViewData["Name"] = user.FirstName;
            var reservations = _reservationService.GetTodayArrivals();
            var reservationsViewModel = _mapper.Map<List<ArrivalsOfTheDayViewModel>>(reservations);
            return View(reservationsViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
