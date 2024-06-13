using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Date;
using GestorPaciente.Core.Application.ViewModels.User;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Services
{
    public class UserService : GenericService<UserViewModel, UserSaveViewModel, User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper):base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> LoginAsync(LoginViewModel vm)
        {
            var user = await _repository.LoginAsync(vm);
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserViewModel>(user);
            
        }

        public async Task<List<UserViewModel>> GetAllInclude()
        {
            var user = await _repository.GetAllIncludeAsync(new List<string> { "Role"});
            return user.Select(x => new UserViewModel
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Username = x.Username,
                Email = x.Email,
                RoleId = x.RoleId,
                RoleName = x.Role.Name
            }).ToList();
        }
    }
}
