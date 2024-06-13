using GestorPaciente.Core.Application.ViewModels.LaboratoryTest;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface ILaboratoryTestService:IGenericService<LaboratoryTestViewModel, LaboratoryTestSaveViewModel, LaboratoryTest>
    {
    }
}
