using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Doctor;
using GestorPaciente.Core.Application.ViewModels.Patient;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Services
{
    public class DoctorService : GenericService<DoctorViewModel, DoctorSaveViewModel, Doctor>, IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository repository, IMapper mapper):base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DoctorSaveViewModel> CreateWithImage(DoctorSaveViewModel vm)
        {
            var doctor = _mapper.Map<Doctor>(vm);
            doctor = await _repository.AddWithImage(doctor);

            DoctorSaveViewModel svm = new();
            svm.Id = doctor.Id;
            svm.Identification = doctor.Identification;
            svm.Name = doctor.Name;
            svm.Email = doctor.Email;
            svm.File = vm.File;
            svm.LastName = doctor.LastName;
            svm.Phone = doctor.Phone;

            return svm;
        }
    }
}
