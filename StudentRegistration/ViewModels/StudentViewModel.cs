using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.ViewModels 
{
    public class StudentViewModel : ViewModelBase
    {
        public Guid StudentId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo de caracteres é 250")]
        [MinLength(2, ErrorMessage = "O nome deve ter no mínimo de caracteres é 2")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MaxLength(100, ErrorMessage = "O CPF deve ter no máximo de caracteres é 11")]
        public string Cpf { get; set; }
        public ICollection<PhoneViewModel> Phones { get; set; }
    }
}