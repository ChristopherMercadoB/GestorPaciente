using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Repositories
{
    public interface IPatientRepository:IGenericRepository<Patient>
    {
        Task<Patient> AddWithImage(Patient entity);
        Task<Patient> GetByIdentificationAsync(string identification);
    }
}
