using GestorPaciente.Core.Application.ViewModels.Date;
using GestorPaciente.Core.Application.ViewModels.LaboratoryTest;
using GestorPaciente.Core.Application.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.ViewModels.LaboratoryTestResult
{
    public class LaboratoryTestResultSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public bool State { get; set; }
        public string? Result { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public List<int> LaboratoriesId { get; set; }
        [NotMapped]
        public int? LaboratoryTestId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public int PatientId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public int DateId { get; set; }
        [NotMapped]
        public List<LaboratoryTestViewModel>? LaboratoryTests { get; set; }
        [NotMapped]

        public List<PatientViewModel>? Patients { get; set; }
        [NotMapped]

        public List<DateViewModel>? Dates { get; set; }
    }
}
