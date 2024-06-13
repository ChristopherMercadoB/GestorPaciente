using GestorPaciente.Core.Application.ViewModels.User;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginViewModel vm);
    }
}
