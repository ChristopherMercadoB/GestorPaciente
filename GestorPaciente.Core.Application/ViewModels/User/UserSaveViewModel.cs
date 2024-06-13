using GestorPaciente.Core.Application.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.ViewModels.User
{
    public class UserSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coiciden")]
        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public int RoleId { get; set; }
        [NotMapped]
        public List<RoleViewModel>? Roles { get; set; }
    }
}
