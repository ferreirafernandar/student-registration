using StudentRegistration.Utils;
using System;

namespace StudentRegistration.Models
{
    public class Phone : ModelBase
    {
        public Guid PhoneId { get; set; } = Guid.NewGuid();
        public Guid? StudentId { get; set; }
        public string Number { get; set; }
        public EnumPhoneType Tipo { get; set; }

        public virtual Student Student { get; set; }
    }
}