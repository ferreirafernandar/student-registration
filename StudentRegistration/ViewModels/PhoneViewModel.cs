using System;
using System.ComponentModel.DataAnnotations;
using StudentRegistration.Utils;

namespace StudentRegistration.ViewModels
{
    public class PhoneViewModel
    {
        public Guid PhoneId { get; set; } = Guid.NewGuid();
        public Guid? StudentId { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O tipo de telefone é obrigatório")]
        public EnumPhoneType Tipo { get; set; }
    }
}