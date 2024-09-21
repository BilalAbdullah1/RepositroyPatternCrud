using Microsoft.AspNetCore.Mvc;
using newproj.Models;
using newproj.RepositoryPattern.Interface;

namespace newproj.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsers _users;
        public UserController(IUsers users)
        {
            _users = users;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersList()
        {
            var data = await _users.GetUsersAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails(int id)
        {
            var data = await _users.GetUserById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UserCreate(Users user, IFormFile image)
        {
            await _users.UserCreate(user, image);
            return RedirectToAction("GetUsersList");
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(int id)
        {
            var users = await _users.GetUserById(id);
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(Users user, IFormFile image)
        {
            var data = await _users.UserUpdate(user, image);
            return RedirectToAction("GetUsersList");
        }

        [HttpGet]
        public async Task<IActionResult> UserDelete(int id)
        {
            var data = await _users.GetUserDeleteById(id);
            return RedirectToAction("GetUsersList");
        }

        [HttpGet]
        public IActionResult griddata()
        {
            return View();
        }

        
    }
}
