using GestorPaciente.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Patient:AuditableBaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Identification { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Smoker { get; set; }
        public bool Alergies { get; set; }
        public string? ImageUrl { get; set; }
        public List<Date> Dates { get; set; }
        public List<LaboratoryTestResult> LaboratoryTestResults { get; set; }
    }
}
