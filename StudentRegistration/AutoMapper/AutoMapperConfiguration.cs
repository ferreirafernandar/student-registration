﻿using AutoMapper;

namespace StudentRegistration.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(p =>
                                           {
                                               p.AddProfile(new DomainToViewModelMappingProfile());
                                               p.AddProfile(new ViewModelToDomainMappingProfile());
                                           });
        }
    }
}