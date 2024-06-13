using GestorPaciente.Core.Domain.Common;


namespace GestorPaciente.Core.Domain.Entities
{
    public class User:AuditableBaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
