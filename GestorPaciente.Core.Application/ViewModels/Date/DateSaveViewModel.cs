using GestorPaciente.Core.Application.ViewModels.Doctor;
using GestorPaciente.Core.Application.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.ViewModels.Date
{
    public class DateSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Este campo es requerido")]
        public string DateDay { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string DateTime { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Reason { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public bool State { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public int PatientId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public int DoctorId { get; set; }
        [NotMapped]
        public List<PatientViewModel>? Patients { get; set; }
        [NotMapped]

        public List<DoctorViewModel>? Doctors { get; set; }


    }
}
