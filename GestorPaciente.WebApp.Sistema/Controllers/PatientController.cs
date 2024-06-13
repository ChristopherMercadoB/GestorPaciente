using GestorPaciente.Core.Application.Helpers;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Patient;
using GestorPaciente.WebApp.Sistema.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Sistema.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly ValidationUser _validation;
        private readonly CheckIsRegistered _check;

        public PatientController(IPatientService patientService, ValidationUser validate, CheckIsRegistered check )
        {
            _patientService = patientService;
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
            return View(await _patientService.GetAll()) ;
        }

        public IActionResult Create()
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (!_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View(new PatientSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var patientVm = await _patientService.CreateWithImage(vm);
            if (patientVm.File != null && patientVm.Id != null)
            {
                patientVm.ImageUrl = UploadFile.UploadImage(vm.File, "Patient", patientVm.Id);
                await _patientService.Update(patientVm, patientVm.Id);
            }
            
            return RedirectToRoute(new {controller="Patient", action="Index"});
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
            var vm = await _patientService.GetById(id);
            return View("Create", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PatientSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", vm);
            }
            var pvm =  await _patientService.GetById(vm.Id);
            vm.ImageUrl = UploadFile.UploadImage(vm.File, "Patient", vm.Id, true, pvm.ImageUrl);
            await _patientService.Update(vm, vm.Id);
            return RedirectToRoute(new {controller="Patient", action="Index"});
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
            var vm = await _patientService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            UploadFile.RemoveUploadedImage("Patient", id);
            await _patientService.Delete(id);
            return RedirectToRoute(new { controller = "Patient", action = "Index" });
        }


    }
}
