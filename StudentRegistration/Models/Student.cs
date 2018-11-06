using System;
using System.Collections.Generic;
using DomainValidation.Validation;
using StudentRegistration.Utils;

namespace StudentRegistration.Models
{
    public class Student : ModelBase
    {

        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }

        public virtual ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            if (!ValidaCpf.IsValid(Cpf))
            {
                ValidationResult.Add(new ValidationError("CPF inválido!"));
                return false;
            }
            return true;
        }
    }
}