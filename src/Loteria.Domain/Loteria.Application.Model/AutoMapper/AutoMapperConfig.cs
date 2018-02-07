using AutoMapper;
using Loteria.Application.Model.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Application.Model.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelProfile());
                cfg.AddProfile(new ViewModelToDomainProfile());
            });
        }
    }
}
