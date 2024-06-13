using GestorPaciente.Core.Application.ViewModels.Doctor;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IDoctorService:IGenericService<DoctorViewModel, DoctorSaveViewModel, Doctor>
    {
        Task<DoctorSaveViewModel> CreateWithImage(DoctorSaveViewModel vm);
    }
}
