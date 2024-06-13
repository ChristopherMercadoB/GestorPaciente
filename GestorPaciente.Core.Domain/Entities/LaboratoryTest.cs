using GestorPaciente.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Domain.Entities
{
    public class LaboratoryTest:AuditableBaseEntity
    {
        public string Name { get; set; }
        public List<LaboratoryTestResult> LaboratoryTestResults { get; set; }
    }
}
