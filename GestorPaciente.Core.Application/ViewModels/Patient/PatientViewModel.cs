
namespace GestorPaciente.Core.Application.ViewModels.Patient
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Identification { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Smoker { get; set; }
        public bool Alergies { get; set; }
        public string? ImageUrl { get; set; }
    }
}
