using GestorPaciente.Core.Application.Interfaces.Repositories;
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
    public class RoleRepository:GenericRepository<Role>, IRoleRepository
    {
        private readonly ApplicationContext _context;
        public RoleRepository(ApplicationContext context):base(context) 
        {
            _context = context;
        }

        public async Task<Role> GetByNameAsync(string name)
        {
            Role? role = await _context.Set<Role>().FirstOrDefaultAsync(r=>r.Name == name);
            return role;
        }
    }
}
