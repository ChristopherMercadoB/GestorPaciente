using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Date;
using GestorPaciente.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPaciente.Core.Domain.Entities;


namespace GestorPaciente.Core.Application.Services
{
    public class DateService:GenericService<DateViewModel, DateSaveViewModel, Date>, IDateService
    {
        private readonly IDateRepository _repository;
        private readonly ILaboratoryTestResultService _resultService;
        private readonly IMapper _mapper;

        public DateService(IDateRepository repository, IMapper mapper, ILaboratoryTestResultService result) :base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _resultService = result;

        }

        public async Task<List<DateViewModel>> GetAllInclude()
        {
            var results = await _resultService.GetAll();
            var user = await _repository.GetAllIncludeAsync(new List<string> { "Doctor", "Patient" });
            return user.Select(x => new DateViewModel
            {
                Id = x.Id,
                DateDay = x.DateDay,
                DateTime = x.DateTime,
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
                Reason = x.Reason,
                State = x.State,
                DoctorName = x.Doctor.Name,
                PatientName = x.Patient.Name,
                Results =  results.Where(r=>r.DateId == x.Id).Select(y=>new LaboratoryTestResultViewModel
                {
                    Id =y.Id,
                    State = y.State,
                    LaboratoryTestId = y.LaboratoryTestId,
                    PatientId = y.PatientId,
                    DateId = y.DateId

                }).ToList()                
               
            }).ToList();
        }

    }
}
