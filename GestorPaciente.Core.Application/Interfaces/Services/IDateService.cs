using GestorPaciente.Core.Application.ViewModels.Date;
using GestorPaciente.Core.Domain.Entities;


namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IDateService:IGenericService<DateViewModel, DateSaveViewModel, Date>
    {
        Task<List<DateViewModel>> GetAllInclude();
    }
}
