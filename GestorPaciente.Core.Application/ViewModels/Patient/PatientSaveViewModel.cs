﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.ViewModels.Patient
{
    public class PatientSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.PhoneNumber)]

        public string Phone { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Identification { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.DateTime)]

        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public bool Smoker { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public bool Alergies { get; set; }

        public string? ImageUrl { get; set; }
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
