using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Repositories
{
    public interface IDoctorRepository:IGenericRepository<Doctor>
    {
        Task<Doctor> AddWithImage(Doctor entity);
    }
}
