using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<User, UserAddDto>.NewConfig();
            TypeAdapterConfig<User, UserDto>.NewConfig();
            TypeAdapterConfig<User, UserUpdateDto>.NewConfig();
            TypeAdapterConfig<User, UserDetailDto>.NewConfig()
                    .Map(dest => dest.Gender, src => src.Gender ? "Kadın" : "Erkek");
        }
    }
}
