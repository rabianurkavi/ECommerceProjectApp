using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Mapster;
using Microsoft.AspNetCore.Routing.Constraints;
using WebAPIWithCoreMvc.ViewModels;

namespace WebAPIWithCoreMvc.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<UserAddViewModel, UserAddDto>.NewConfig()
             .Map(dest => dest.Gender, src => src.GenderId == 1);
        }
    }
}
