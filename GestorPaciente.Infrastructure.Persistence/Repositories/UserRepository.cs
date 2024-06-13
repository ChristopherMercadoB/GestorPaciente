using GestorPaciente.Core.Application.Helpers;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.ViewModels.User;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }

        public override Task AddAsync(User entity)
        {
            entity.Password = PasswordEncryption.computeSha256Hash(entity.Password);

            return base.AddAsync(entity);
        }

        public async Task<User> LoginAsync(LoginViewModel vm)
        {
            vm.Password = PasswordEncryption.computeSha256Hash(vm.Password);
            User? user = await _context.Set<User>()
                .FirstOrDefaultAsync(u=>u.Username == vm.Username && u.Password == vm.Password);
            return user;
        }
    }
}
