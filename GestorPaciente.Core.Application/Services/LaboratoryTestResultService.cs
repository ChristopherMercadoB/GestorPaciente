using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPaciente.Core.Domain.Entities;


namespace GestorPaciente.Core.Application.Services
{
    public class LaboratoryTestResultService : GenericService<LaboratoryTestResultViewModel, LaboratoryTestResultSaveViewModel, LaboratoryTestResult>, ILaboratoryTestResultService
    {
        private readonly ILaboratoryTestResultRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public LaboratoryTestResultService(ILaboratoryTestResultRepository repository, IMapper mapper, IPatientRepository patientRepository):base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task CreateWithMany(LaboratoryTestResultSaveViewModel vm)
        {
            foreach (var item in vm.LaboratoriesId)
            {
                LaboratoryTestResultSaveViewModel lvm = new();
                lvm.DateId = vm.DateId;
                lvm.PatientId = vm.PatientId;
                lvm.State = vm.State;
                lvm.Result = vm.Result;
                lvm.LaboratoryTestId = item;

                LaboratoryTestResult result = new();
                result.Result = lvm.Result;
                result.PatientId = lvm.PatientId;
                result.State = lvm.State;
                result.LaboratoryTestId = lvm.LaboratoryTestId;
                result.DateId = lvm.DateId;

                await _repository.AddAsync(result);
            }
            
        }

        public async Task<List<LaboratoryTestResultViewModel>> GetAllByDateId(int id)
        {
            var result = await _repository.GetAllIncludeAsync(new List<string> { "Patient", "Date", "LaboratoryTest" });
            return result.Where(r=>r.DateId == id).Select(x => new LaboratoryTestResultViewModel
            {
                Id = x.Id,
                State = x.State,
                PatientId = x.PatientId,
                DateId = x.DateId,
                LaboratoryTestId = x.LaboratoryTestId,
                Result = x.Result,
                PatientName = x.Patient.Name,
                PatientLastName = x.Patient.LastName,
                PatientIdentification = x.Patient.Identification,
                LaboratoryTestName = x.LaboratoryTest.Name,
            }).ToList();

            

            
        }

        public async Task<List<LaboratoryTestResultViewModel>> GetAllInclude(bool withoutComplete = true)
        {
            var result = await _repository.GetAllIncludeAsync(new List<string> { "Patient", "Date", "LaboratoryTest" });
            return result.Where(x=>x.State == false).Select(x => new LaboratoryTestResultViewModel
            {
                Id = x.Id,
                State = x.State,
                PatientId = x.PatientId,
                DateId = x.DateId,
                LaboratoryTestId = x.LaboratoryTestId,
                Result = x.Result,
                PatientName = x.Patient.Name,
                PatientLastName = x.Patient.LastName,
                PatientIdentification = x.Patient.Identification,
                LaboratoryTestName = x.LaboratoryTest.Name,
            }).ToList();

           

            

        }

        public async Task<List<LaboratoryTestResultViewModel>> GetAllWithFilters(FilterPatientViewModel vm)
        {
            var result = await _repository.GetAllIncludeAsync(new List<string> { "Patient", "Date", "LaboratoryTest"});
            var list = result.Where(x=>x.State==false).Select(x=>new LaboratoryTestResultViewModel
            {
                Id = x.Id,
                State = x.State,
                PatientId = x.PatientId,
                DateId = x.DateId,
                LaboratoryTestId = x.LaboratoryTestId,
                Result = x.Result,
                PatientName = x.Patient.Name,
                PatientLastName = x.Patient.LastName,
                PatientIdentification = x.Patient.Identification,
                LaboratoryTestName = x.LaboratoryTest.Name,
            }).ToList();

            if (vm.Identification != null)
            {
                var patient = await _patientRepository.GetByIdentificationAsync(vm.Identification);
                if (patient == null)
                {
                    return null;
                }
                else
                {
                    list = list.Where(r => r.PatientId == patient.Id).ToList();
                }

            }

            return list;
        }
    }
}
