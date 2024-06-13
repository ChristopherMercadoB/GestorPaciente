using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository:GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly ApplicationContext _context;
        public DoctorRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }

        public async Task<Doctor> AddWithImage(Doctor entity)
        {
            await _context.Set<Doctor>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
