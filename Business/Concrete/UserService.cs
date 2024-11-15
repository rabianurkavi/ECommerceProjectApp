using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal; 
        }
        public async Task<UserDto> AddAsync(UserAddDto entity)
        {
            var user = entity.Adapt<User>();
            var addedUser = await _userDal.AddAsync(user);
            return addedUser.Adapt<UserDto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Kullanıcıyı kontrol et
            var user = await _userDal.GetAsync(x => x.ID == id);
            if (user == null)
            {
                return false; 
            }
            await _userDal.DeleteAsync(id);
            return true; 
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var users = await _userDal.GetAsync(x=>x.ID==id);
            var userDto= users.Adapt<UserDto>();
            return userDto;
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            var users = await _userDal.GetListAsync();
            var userDtos= users.Adapt<IEnumerable<UserDetailDto>>();
            return userDtos;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var existingUser = await _userDal.GetAsync(x => x.ID == userUpdateDto.ID);
            userUpdateDto.Adapt(existingUser);
            await _userDal.UpdateAsync(existingUser);
            return userUpdateDto;
        }
    }
}
