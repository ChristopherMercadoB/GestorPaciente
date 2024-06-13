using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Services
{
    public class GenericService<ViewModel, SaveViewModel, Entity> : IGenericService<ViewModel, SaveViewModel, Entity> 
        where ViewModel : class
        where SaveViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task Create(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _repository.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<ViewModel>> GetAll()
        {
            var entityList = await _repository.GetAllAsync();
            List<ViewModel> viewModels = _mapper.Map<List<ViewModel>>(entityList);
            return viewModels;
        }

        public async Task<SaveViewModel> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);
            return vm;
        }

        public async Task Update(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _repository.UpdateAsync(entity, id);
        }
    }
}
