using GestorPaciente.Core.Application.ViewModels.Patient;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IPatientService:IGenericService<PatientViewModel, PatientSaveViewModel, Patient>
    {
        Task<PatientSaveViewModel> CreateWithImage(PatientSaveViewModel vm);
    }
}
