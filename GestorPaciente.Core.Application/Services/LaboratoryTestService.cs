using AutoMapper;
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModels.Date;
using GestorPaciente.Core.Application.ViewModels.LaboratoryTest;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Services
{
    public class LaboratoryTestService : GenericService<LaboratoryTestViewModel, LaboratoryTestSaveViewModel, LaboratoryTest>, ILaboratoryTestService
    {
        private readonly ILaboratoryTestRepository _repository;
        private readonly IMapper _mapper;

        public LaboratoryTestService(ILaboratoryTestRepository repository, IMapper mapper):base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
