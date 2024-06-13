using GestorPaciente.Core.Domain.Common;


namespace GestorPaciente.Core.Domain.Entities
{
    public class Date:AuditableBaseEntity
    {
        public string DateDay { get; set; }
        public string DateTime { get; set; }
        public string Reason { get; set; }
        public bool State { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<LaboratoryTestResult> LaboratoryTestResults { get; set; }
    }
}
