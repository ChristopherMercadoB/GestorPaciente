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
    public class LaboratoryTestRepository : GenericRepository<LaboratoryTest>, ILaboratoryTestRepository
    {
        private readonly ApplicationContext _context;
        public LaboratoryTestRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }
    }
}
