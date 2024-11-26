using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIWithCoreMvc.Controllers
{
    public class UsersController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "http://localhost:5065/api/";
        #endregion
        #region Constructor
        public UsersController(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserDetailDto>>(url+"User/GetList");
            return View(users);
        }
    }
}
