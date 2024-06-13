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
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationContext _context;
        public PatientRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }

        public async Task<Patient> AddWithImage(Patient entity)
        {
            await _context.Set<Patient>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Patient> GetByIdentificationAsync(string identification)
        {
            return await _context.Set<Patient>()
                 .FirstOrDefaultAsync(p=>p.Identification == identification || p.Identification.Contains(identification));
        }
    }
}
