using GestorPaciente.Core.Application.ViewModels.User;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GestorPaciente.WebApp.Sistema.Middleware
{
    public class CheckIsRegistered
    {
        private readonly ApplicationContext _context;
        public CheckIsRegistered(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIsUserRegistered(UserSaveViewModel vm)
        {
            var user = await _context.Set<User>()
                .FirstOrDefaultAsync(u=>u.Username == vm.Username);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
