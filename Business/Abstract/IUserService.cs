using Core.Helpers.JWT;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetailDto>> GetListAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> AddAsync(UserAddDto entity);
        Task<UserUpdateDto> UpdateAsync(UserUpdateDto user);
        Task<bool> DeleteAsync(int id);
        Task<AccessToken> Authenticate(UserForLoginDto userForLoginDto);
    }
}
