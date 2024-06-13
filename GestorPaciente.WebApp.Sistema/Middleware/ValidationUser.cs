using GestorPaciente.Core.Application.Helpers;
using GestorPaciente.Core.Application.ViewModels.User;

namespace GestorPaciente.WebApp.Sistema.Middleware
{
    public class ValidationUser
    {
        private readonly UserViewModel vm;
        public ValidationUser(IHttpContextAccessor accessor)
        {
            vm = accessor.HttpContext.Session.GetSession<UserViewModel>("user");
        }

        public bool HasUser()
        {
            if (vm == null)
            {
                return false;
            }

            return true;

        }

        public bool HasAssistant()
        {
            if (vm.RoleId != 1)
            {
                return true;
            }
            return false;
        }
    }
}
