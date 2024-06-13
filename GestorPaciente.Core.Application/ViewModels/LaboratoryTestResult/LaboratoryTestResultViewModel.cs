using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.ViewModels.LaboratoryTestResult
{
    public class LaboratoryTestResultViewModel
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public string? Result { get; set; }
        public int? LaboratoryTestId { get; set; }
        public int PatientId { get; set; }
        public int DateId { get; set; }
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientIdentification { get; set; }
        public string LaboratoryTestName { get; set; }
    }
}
