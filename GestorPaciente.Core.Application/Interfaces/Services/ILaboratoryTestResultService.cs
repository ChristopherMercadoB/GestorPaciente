using GestorPaciente.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface ILaboratoryTestResultService:IGenericService<LaboratoryTestResultViewModel, LaboratoryTestResultSaveViewModel, LaboratoryTestResult>
    {
        Task<List<LaboratoryTestResultViewModel>> GetAllWithFilters(FilterPatientViewModel vm);
        Task<List<LaboratoryTestResultViewModel>> GetAllByDateId(int id);
        Task CreateWithMany(LaboratoryTestResultSaveViewModel vm);
        Task<List<LaboratoryTestResultViewModel>> GetAllInclude(bool withoutComplete = true);


    }
}
