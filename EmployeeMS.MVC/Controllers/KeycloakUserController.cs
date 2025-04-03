using EmployeeMS.MVC.Services;
using EmployeeMS.Shared.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMS.MVC.Controllers
{
    public class KeycloakUserController : Controller
    {
        private readonly KeycloakUserService _userService;

        public KeycloakUserController(KeycloakUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            List<KeycloakUser> users = await _userService.GetUsersAsync();
            return View(users);
        }
    }
}
