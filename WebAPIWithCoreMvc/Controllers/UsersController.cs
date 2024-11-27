using Entities.Dtos.UserDtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebAPIWithCoreMvc.ViewModels;

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
            _httpClient = httpClient;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "User/GetList");
            return View(users);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            ViewBag.GenderList = GenderFill();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddViewModel userAddViewModel)
        {
            var userAddDto = userAddViewModel.Adapt<UserAddDto>();
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "User/Add", userAddDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<UserUpdateDto>(url + "User/GetById/" + id);
            UserUpdateViewModel userUpdateViewModel = user.Adapt<UserUpdateViewModel>();
            ViewBag.GenderList = GenderFill();
            return View(userUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(int userId, UserUpdateViewModel userUpdateViewModel)
        {
            var userUpdateDto = userUpdateViewModel.Adapt<UserUpdateDto>();
            HttpResponseMessage responseMessage = await _httpClient.PutAsJsonAsync(url + "User/Update", userUpdateDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{url}User/Delete/{id}");
            return RedirectToAction("Index");

        }
        private List<Gender> GenderFill()
        {
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender() { Id = 1, GenderName = "Kadın" });
            genders.Add(new Gender() { Id = 2, GenderName = "Erkek" });
            return genders;
        }
        private class Gender
        {
            public int Id { get; set; }
            public string GenderName { get; set; }
        }
    }
}
