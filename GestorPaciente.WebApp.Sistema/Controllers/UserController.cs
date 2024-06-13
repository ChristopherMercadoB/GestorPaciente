using AutoMapper;
using GestorPaciente.Core.Application.Helpers;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.Services;
using GestorPaciente.Core.Application.ViewModels.Date;
using GestorPaciente.Core.Application.ViewModels.User;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.WebApp.Sistema.Middleware;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace GestorPaciente.WebApp.Sistema.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly CheckIsRegistered _check;
        private readonly ValidationUser _validation;
        public UserController(IUserService userService, IRoleService roleService, IMapper mapper, CheckIsRegistered checks, ValidationUser validation)
        {
            _userService = userService;
            _roleService = roleService;
            _check = checks;
            _validation = validation;

        }
        public IActionResult Login()
        {
            if (_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View();
        }

        public async Task<IActionResult> Index()
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }else if (_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(await _userService.GetAllInclude());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            var user = await _userService.LoginAsync(vm);
            if (user != null)
            {
                HttpContext.Session.SetSession<UserViewModel>("user", user);
                return RedirectToRoute(new {controller="Home", action="Index"});
            }
            return View();
        }

        public async Task<IActionResult> Register()
        {

            UserSaveViewModel vm = new();
            vm.Roles = await _roleService.GetAll();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserSaveViewModel vm)
        {
            vm.Roles = await _roleService.GetAll();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            bool isRegistered = await _check.CheckIsUserRegistered(vm);
            if (!isRegistered)
            {
                await _userService.Create(vm);
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else
            {

                ModelState.AddModelError("userValidation", "Ya hay un usuario registrado con ese nombre");
            }

            return View(vm);

        }

        public IActionResult Logout()
        {
            var user = HttpContext.Session.GetSession<UserViewModel>("user");
            if (user!=null)
            {
                HttpContext.Session.Remove("user");
                return RedirectToRoute(new {controller="User", action="Index"});
            }
            return View("Index");
        }

        public async Task<IActionResult> Update(int id)
        {

            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var vm = await _userService.GetById(id);
            vm.Roles = await _roleService.GetAll();

            return View("Register", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserSaveViewModel vm, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", vm);

            }
            await _userService.Update(vm, id);
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            var vm = await _userService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _userService.Delete(id);
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }


    }
}
