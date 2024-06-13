using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPaciente.WebApp.Sistema.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Sistema.Controllers
{
    public class LaboratoryTestResultController : Controller
    {
        private readonly ILaboratoryTestResultService _laboratoryTestResultService;
        private readonly IDateService _dateService;
        private readonly IPatientService _patientService;
        private readonly ILaboratoryTestService _laboratoryTestService;
        private readonly ValidationUser _validation;
        private readonly CheckIsRegistered _check;

        public LaboratoryTestResultController(ILaboratoryTestResultService laboratoryTestResultService, 
            IDateService dateService, IPatientService patientService, ILaboratoryTestService laboratoryTestService, 
            ValidationUser validate, CheckIsRegistered check)
        {
            _laboratoryTestResultService = laboratoryTestResultService;
            _dateService = dateService;
            _patientService = patientService;
            _laboratoryTestService = laboratoryTestService;
            _check = check;
            _validation = validate;
        }
        public async Task<ActionResult> Index(FilterPatientViewModel vm)
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (!_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View(await _laboratoryTestResultService.GetAllWithFilters(vm));
        }

        public async Task<IActionResult> Create(int id)
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (!_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            LaboratoryTestResultSaveViewModel vm = new();
            vm.Patients = await _patientService.GetAll();
            vm.LaboratoryTests = await _laboratoryTestService.GetAll();
            vm.Dates = await _dateService.GetAll();
            ViewBag.Date = await _dateService.GetById(id);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LaboratoryTestResultSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Patients = await _patientService.GetAll();
                vm.LaboratoryTests = await _laboratoryTestService.GetAll();
                vm.Dates = await _dateService.GetAll();
                ViewBag.Date = await _dateService.GetById(vm.DateId);
                return View(vm);
            }
            await _laboratoryTestResultService.CreateWithMany(vm);
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
            var vm = await _laboratoryTestResultService.GetById(id);
            vm.Patients = await _patientService.GetAll();
            vm.LaboratoryTests = await _laboratoryTestService.GetAll();
            vm.Dates = await _dateService.GetAll();
            return View("Index", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LaboratoryTestResultSaveViewModel vm, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", vm);

            }
            await _laboratoryTestResultService.Update(vm, id);
            return RedirectToRoute(new {controller= "LaboratoryTestResult", action="Index"});
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
            var vm = await _laboratoryTestResultService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _laboratoryTestResultService.Delete(id);
            return RedirectToRoute(new { controller = "LaboratoryTestResult", action = "Index" });
        }

        public async Task<IActionResult> Report(int id)
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (!_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            var vm = await _laboratoryTestResultService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Report(LaboratoryTestResultSaveViewModel vm, int id)
        {
            if (vm != null)
            {
                vm.State = true;
                await _laboratoryTestResultService.Update(vm, id);
            }
            
            return RedirectToRoute(new {controller="LaboratoryTestResult", action="Index"});
        }

        public async Task<IActionResult> ConsultReport(int id)
        {
            if (!_validation.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else if (!_validation.HasAssistant())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            ViewBag.Date = await _dateService.GetById(id);
            return View(await _laboratoryTestResultService.GetAllByDateId(id));
        }


    }
}
