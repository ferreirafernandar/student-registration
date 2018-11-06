using System;
using AutoMapper;
using DomainValidation.Validation;
using StudentRegistration.Models;
using StudentRegistration.ViewModels;

namespace StudentRegistration.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<StudentViewModel, Student>()
                .ForMember(c => c.StudentId, d => d.MapFrom(c => c.StudentId == null || c.StudentId == Guid.Empty ? Guid.NewGuid() : c.StudentId))
                .ForMember(c => c.ValidationResult, d => d.UseValue(new ValidationResult()));

            CreateMap<PhoneViewModel, Phone>();
        }
    }
}