using GestorPaciente.Core.Application.ViewModels.User;
using GestorPaciente.Core.Domain.Entities;


namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IUserService:IGenericService<UserViewModel, UserSaveViewModel, User>
    {
        Task<UserViewModel> LoginAsync(LoginViewModel vm);
        Task<List<UserViewModel>> GetAllInclude();
    }
}
