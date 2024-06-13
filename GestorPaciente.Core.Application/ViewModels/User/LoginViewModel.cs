using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Este campo es requerido")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
