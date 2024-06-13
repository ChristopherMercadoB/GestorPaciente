using GestorPaciente.Core.Application.ViewModels.LaboratoryTestResult;
using GestorPaciente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.ViewModels.Date
{
    public class DateViewModel
    {
        public int Id { get; set; }
        public string DateDay { get; set; }
        public string DateTime { get; set; }
        public string Reason { get; set; }
        public bool State { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public List<LaboratoryTestResultViewModel> Results { get; set; }
    }
}
