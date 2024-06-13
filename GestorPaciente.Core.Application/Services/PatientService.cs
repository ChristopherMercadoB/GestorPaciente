using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Patient;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Services
{
    public class PatientService : GenericService<PatientViewModel, PatientSaveViewModel, Patient>, IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository repository, IMapper mapper):base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientSaveViewModel> CreateWithImage(PatientSaveViewModel vm)
        {
            var patient = _mapper.Map<Patient>(vm);
            patient = await _repository.AddWithImage(patient);

            PatientSaveViewModel svm = new();
            svm.Id = patient.Id;
            svm.Identification = patient.Identification;
            svm.Name = patient.Name;
            svm.Address = patient.Address;
            svm.Birthdate = patient.Birthdate;
            svm.Alergies = patient.Alergies;
            svm.Smoker = patient.Smoker;
            svm.File = vm.File;
            svm.LastName = patient.LastName;
            svm.Phone = patient.Phone;

            return svm;
           
        }
    }
}
