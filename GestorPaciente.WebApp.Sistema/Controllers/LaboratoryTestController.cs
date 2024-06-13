using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.LaboratoryTest;
using GestorPaciente.WebApp.Sistema.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Sistema.Controllers
{
    public class LaboratoryTestController : Controller
    {
        private readonly ILaboratoryTestService _laboratoryTestService;
        private readonly ValidationUser _validation;
        private readonly CheckIsRegistered _check;

        public LaboratoryTestController(ILaboratoryTestService laboratoryTestService, ValidationUser validate, CheckIsRegistered check)
        {
            _laboratoryTestService = laboratoryTestService;
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
            return View(await _laboratoryTestService.GetAll());
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
            return View(new LaboratoryTestSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LaboratoryTestSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _laboratoryTestService.Create(vm);
            return RedirectToRoute(new {controller="LaboratoryTest", action="Index"});
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
            var vm = await _laboratoryTestService.GetById(id);
            return View("Create", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LaboratoryTestSaveViewModel vm, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", vm);

            }
            await _laboratoryTestService.Update(vm, id);
            return RedirectToRoute(new {controller="LaboratoryTest", action="Index"});
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
            var vm = await _laboratoryTestService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _laboratoryTestService.Delete(id);
            return RedirectToRoute(new { controller = "LaboratoryTest", action = "Index" });
        }


    }
}
