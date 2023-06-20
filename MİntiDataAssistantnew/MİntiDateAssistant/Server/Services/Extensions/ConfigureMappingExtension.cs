using AutoMapper;
using MİntiDateAssistant.Server.Data.Models;
using Microsoft.Extensions.DependencyInjection;

using MİntiDateAssistant.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MealOrdering.Server.Services.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

    

            CreateMap<MinticityUser, UserDTO>();
            CreateMap<Activity, ActivityDTO>();




            //CreateMap<UserDTO, MinticityUser>()
            //    .ForMember(x => x.Password, y => y.MapFrom(z => PasswordEncrypter.Encrypt(z.Password)))
            //    ;


        }
    }
}