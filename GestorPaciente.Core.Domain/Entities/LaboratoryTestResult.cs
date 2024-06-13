using GestorPaciente.Core.Domain.Common;


namespace GestorPaciente.Core.Domain.Entities
{
    public class LaboratoryTestResult:AuditableBaseEntity
    {
        public bool State { get; set; }
        public int? LaboratoryTestId { get; set; }
        public LaboratoryTest LaboratoryTest { get; set; }
        public int PatientId { get; set; }
        //New property
        public string? Result { get; set; }
        public Patient Patient { get; set; }
        public int DateId { get; set; }
        public Date Date { get; set; }
    }
}
