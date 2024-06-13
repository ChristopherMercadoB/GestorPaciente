using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IGenericService<ViewModel, SaveViewModel, Entity>
        where ViewModel : class
        where SaveViewModel : class
        where Entity : class
    {
        Task Create(SaveViewModel vm);
        Task<List<ViewModel>> GetAll();
        Task Update(SaveViewModel vm, int id);
        Task Delete(int id);
        Task<SaveViewModel> GetById(int id);
    }
}
