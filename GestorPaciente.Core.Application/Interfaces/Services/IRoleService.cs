using GestorPaciente.Core.Application.ViewModels.Role;
using GestorPaciente.Core.Domain.Entities;


namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IRoleService:IGenericService<RoleViewModel, RoleSaveViewModel, Role>
    {
    }
}
