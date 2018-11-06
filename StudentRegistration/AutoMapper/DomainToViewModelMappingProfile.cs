using AutoMapper;
using StudentRegistration.Models;
using StudentRegistration.ViewModels;

namespace StudentRegistration.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>().ForMember(s => s.ValidationResult, s => s.Condition(c => c.ValidationResult != null));
            CreateMap<Phone, PhoneViewModel>();
        }
    }
}