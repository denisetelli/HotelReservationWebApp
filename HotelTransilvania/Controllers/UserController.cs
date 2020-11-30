using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using Commom.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelTransilvania.Controllers
{

    public class UserController : Controller
    {
        private IUserService _service;
        private IRoleService _roleService;

        public UserController(IUserService service, IRoleService roleService)
        {
            _service = service;
            _roleService = roleService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            var users = _service.GetAll();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Index(string name)
        {
            ViewData["CurrentFilter"] = name;
            var user = _service.FindUserByName(name);
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            SetViewBagData();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO user)
        {
            if (IsValidUser(user))
            {
                user.EnrollmentDate = DateTime.Now;
                user.ChangeDate = DateTime.Now;

                _service.Add(user);
                return RedirectToAction("Index");
            }
            else
            {
                SetViewBagData();
                return View(user);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            SetViewBagData();
            UserDTO user = _service.FindById(id);
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDTO user)
        {
            if (IsValidUser(user))
            {
                _service.Edit(user);
                return RedirectToAction("Index");
            }
            else
            {
                SetViewBagData();
                return View(user);
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View(GetLoggedUser());
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            return View(GetLoggedUser());
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UserDTO user)
        {
            if (IsValidUser(user))
            {
                _service.UpdateProfile(user);
                return RedirectToAction("Index", "Home", user);
            }
            else
            {
                SetViewBagData();
                return View(user);
            }
        }

        private void SetViewBagData()
        {
            ViewBag.RoleList = _roleService.Get();
        }

        private bool IsValidUser(UserDTO user)
        {
            if (!_service.IsEmailAvaliable(user.Email, user.UserId))
            {
                ViewData["ErrorMessage"] = "E-mail já cadastrado para outro usuário.";
                return false;
            }
            return true;
        }

        public UserDTO GetLoggedUser()
        {
            var email = this.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            UserDTO user = _service.FindByEmail(email);
            return user;
        }
    }
}

