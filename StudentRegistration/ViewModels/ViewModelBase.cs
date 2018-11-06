using DomainValidation.Validation;

namespace StudentRegistration.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            ValidationResult = new ValidationResult();
        }
        public virtual ValidationResult ValidationResult { get; set; }
    }
}