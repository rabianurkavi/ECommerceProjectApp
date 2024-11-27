using Business.Abstract;
using Core.Helpers.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Mapster;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        AppSettings _appSettings;
        public UserService(IUserDal userDal, IOptions<AppSettings> appSettings)
        {
            _userDal = userDal;
            _appSettings = appSettings.Value;
        }
        public async Task<UserDto> AddAsync(UserAddDto entity)
        {
            var user = entity.Adapt<User>();
            var addedUser = await _userDal.AddAsync(user);
            return addedUser.Adapt<UserDto>();
        }

        public async Task<AccessToken> Authenticate(UserForLoginDto userForLoginDto)
        {
            var user = await _userDal.GetAsync(x => x.UserName == userForLoginDto.UserName && x.Password == userForLoginDto.Password);

            var tokenHandler= new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,user.ID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token= tokenHandler.CreateToken(tokenDescriptor);
            AccessToken accessToken = new AccessToken()
            {
                Token = tokenHandler.WriteToken(token),
                UserName=user.UserName,
                Expiration= (DateTime)tokenDescriptor.Expires,
                UserID=user.ID,
            };
            return await Task.Run(() => accessToken);
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
