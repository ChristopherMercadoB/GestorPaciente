using GestorPaciente.Core.Application.Helpers;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.Services;
using GestorPaciente.Core.Application.ViewModels.Doctor;
using GestorPaciente.Core.Application.ViewModels.Patient;
using GestorPaciente.WebApp.Sistema.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Sistema.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ValidationUser _validation;
        private readonly CheckIsRegistered _check;

        public DoctorController(IDoctorService doctorService, ValidationUser validate, CheckIsRegistered check)
        {
            _doctorService = doctorService;
            _validation = validate;
            _check = check;
        }
        public async Task<ActionResult> Index()
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View(await _doctorService.GetAll());
        }

        public IActionResult Create()
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View(new DoctorSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var doctorVm = await _doctorService.CreateWithImage(vm);
            if (doctorVm.File != null && doctorVm.Id != null)
            {
                doctorVm.ImageUrl = UploadFile.UploadImage(vm.File, "Doctor", doctorVm.Id);
                await _doctorService.Update(doctorVm, doctorVm.Id);
            }
            return RedirectToRoute(new {controller="Doctor", action="Index"});
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
            var vm = await _doctorService.GetById(id);
            return View("Create", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DoctorSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", vm);

            }
            var dvm = await _doctorService.GetById(vm.Id);
            vm.ImageUrl = UploadFile.UploadImage(vm.File, "Doctor", dvm.Id, true, dvm.ImageUrl);
            await _doctorService.Update(vm, vm.Id);
            return RedirectToRoute(new {controller= "Doctor", action="Index"});
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
            var vm = await _doctorService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _doctorService.Delete(id);
            return RedirectToRoute(new { controller = "Doctor", action = "Index" });
        }


    }
}
