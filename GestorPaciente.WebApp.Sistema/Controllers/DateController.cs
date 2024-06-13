using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Date;
using GestorPaciente.Core.Application.ViewModels.Patient;
using GestorPaciente.WebApp.Sistema.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Sistema.Controllers
{
    public class DateController : Controller
    {
        private readonly IDateService _dateService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly ValidationUser _validation;
        private readonly CheckIsRegistered _check;

        public DateController(IDateService dateService, IPatientService patientService, IDoctorService doctorService, ValidationUser validate, CheckIsRegistered check)
        {
            _dateService = dateService;
            _patientService = patientService;
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
            else if (!_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View(await _dateService.GetAllInclude());
        }

        public async Task<IActionResult> ChangeStateOfDate(int id)
        {
            var vm = await _dateService.GetById(id);
            vm.State = true;
            await _dateService.Update(vm, id);
            return RedirectToRoute(new {controller="Date" ,action="Index"});
        }

        public async Task<IActionResult> Create()
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (!_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            var vm = new DateSaveViewModel();
            vm.Patients = await _patientService.GetAll();
            vm.Doctors = await _doctorService.GetAll();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DateSaveViewModel vm)
        {
            vm.Patients = await _patientService.GetAll();
            vm.Doctors = await _doctorService.GetAll();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _dateService.Create(vm);
            return RedirectToRoute(new {controller="Date", action="Index"});
        }

        public async Task<IActionResult> Update(int id)
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (!_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            var vm = await _dateService.GetById(id);
            return View("Index", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DateSaveViewModel vm, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", vm);

            }
            await _dateService.Update(vm, id);
            return RedirectToRoute(new {controller="Date", action="Index"});
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (!_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            var vm = await _dateService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _dateService.Delete(id);
            return RedirectToRoute(new { controller = "Date", action = "Index" });
        }


    }
}
