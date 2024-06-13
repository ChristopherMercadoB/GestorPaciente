using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Role;
using GestorPaciente.Core.Application.ViewModels.User;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Services
{
    public class RoleService : GenericService<RoleViewModel, RoleSaveViewModel, Role>, IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository repository, IMapper mapper):base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
