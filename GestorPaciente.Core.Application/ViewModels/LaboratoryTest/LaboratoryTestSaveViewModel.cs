
using System.ComponentModel.DataAnnotations;

namespace GestorPaciente.Core.Application.ViewModels.LaboratoryTest
{
    public class LaboratoryTestSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Name { get; set; }
    }
}
