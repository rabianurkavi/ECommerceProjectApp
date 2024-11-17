using Business.Abstract;
using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        //FromBody ile otomatik serilazation yaparız yani gelen JSON verisi Dto ya dönüşür.
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] UserAddDto userAddDto)
        {
            var result = await _userService.AddAsync(userAddDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateAsync(userUpdateDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result != null)
                return Ok(true);
            return BadRequest(false);
        }

    }
}
